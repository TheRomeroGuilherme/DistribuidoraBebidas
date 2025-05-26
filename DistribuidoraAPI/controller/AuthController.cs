using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace DistribuidoraAPI.Controllers
{
    [Authorize]
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
            string tipoUsuario = dto.Usuario;
            object usuario = null;

            switch (tipoUsuario)
            {
                case "Distribuidora":
                    usuario = await _context.Distribuidora
                        .FirstOrDefaultAsync(d => d.EmailCorporativo == dto.Email);
                    break;

                case "Fornecedor":
                    usuario = await _context.Fornecedor
                        .FirstOrDefaultAsync(f => f.Email == dto.Email);
                    break;

                case "Entregador":
                    usuario = await _context.Entregador
                        .FirstOrDefaultAsync(e => e.Email == dto.Email);
                    break;

                case "Cliente":
                    usuario = await _context.Clientes
                        .FirstOrDefaultAsync(c => c.Email == dto.Email);
                    break;

                default:
                    return BadRequest("Tipo de usuário inválido.");
            }

            if (usuario == null)
                return Unauthorized("E-mail não encontrado.");

            // Obter senha hash de forma dinâmica
            string senhaHash = usuario switch
            {
                Distribuidora d => d.SenhaHash,
                Fornecedor f => f.SenhaHash,
                Entregador e => e.SenhaHash,
                Cliente c => c.SenhaHash,
                _ => null
            };

            if (senhaHash == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, senhaHash))
                return Unauthorized("Senha incorreta.");

            // Gerar token com tipo e e-mail
            string email = dto.Email;
            string token = TokenService.GerarToken(email, tipoUsuario, _configuration["Jwt:Key"]);

            return Ok(new
            {
                token,
                tipo = tipoUsuario
            });
        }
    }
}
