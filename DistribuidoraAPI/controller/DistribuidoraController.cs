using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;
using DistribuidoraAPI.Models.DTOs;

namespace DistribuidoraAPI.controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DistribuidoraController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public DistribuidoraController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }   

        [HttpPost("login")]
        public async Task<IActionResult> LoginDistribuidora([FromBody] LoginDto dto)
        {
            var distribuidora = await _context.Distribuidora
                .FirstOrDefaultAsync(d => d.EmailCorporativo == dto.Email);

            if (distribuidora == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, distribuidora.SenhaHash))
                return Unauthorized("E-mail ou senha inválidos.");

            var secretKey = _configuration["Jwt:Key"];
            var token = TokenService.GerarToken(distribuidora.EmailCorporativo, "Distribuidora", secretKey);

            return Ok(new { token });
        }


        [HttpPost("{idDistribuidora}/pedidos")]
        public async Task<IActionResult> FazerPedido(int idDistribuidora, [FromBody] PedidoFornecedorDto dto)
        {
            var distribuidora = await _context.Distribuidora.FindAsync(idDistribuidora);
            if (distribuidora == null)
                return NotFound("Distribuidora não encontrada.");

            var produto = await _context.ProdutosFornecedor
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == dto.ProdutoFornecedorId);

            if (produto == null)
                return NotFound("Produto do fornecedor não encontrado.");

            var pedido = new PedidoFornecedor
            {
                DistribuidoraId = idDistribuidora,
                ProdutoFornecedorId = produto.Id,
                Quantidade = dto.Quantidade
            };

            await _context.PedidosFornecedor.AddAsync(pedido);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Pedido feito com sucesso.",
                produto.Nome,
                produto.Preco,
                pedido.Quantidade,
                pedido.DataPedido
            });
        }

    }
}
