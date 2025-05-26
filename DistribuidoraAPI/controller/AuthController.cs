// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Services;

namespace DistribuidoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuario = await _context.Distribuidora.FirstOrDefaultAsync(u => u.EmailCorporativo == dto.Email);
            string tipoUsuario = "Distribuidora";

            if (usuario == null)
            {
                usuario = await _context.Fornecedor.FirstOrDefaultAsync(f => f.Email == dto.Email);
                tipoUsuario = "Fornecedor";
            }

            if (usuario == null)
            {
                usuario = await _context.Entregador.FirstOrDefaultAsync(e => e.Email == dto.Email);
                tipoUsuario = "Entregador";
            }

            if (usuario == null)
            {
                usuario = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == dto.Email);
                tipoUsuario = "Cliente";
            }

            if (usuario == null)
                return Unauthorized("E-mail não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
                return Unauthorized("Senha incorreta.");

            var token = TokenService.GerarToken(dto.Email, tipoUsuario, _configuration["Jwt:Key"]);

            return Ok(new
            {
                token,
                tipo = tipoUsuario
            });
        }
    }
}
