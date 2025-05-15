using Microsoft.AspNetCore.Mvc;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models;
using DistribuidoraAPI.DTOs;
using BCrypt.Net;

namespace DistribuidoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            {
                return BadRequest("Email já cadastrado.");
            }

            // Aqui você criptografa a senha antes de salvar
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.CriadoEm = DateTime.UtcNow; // Se você adicionou esse campo

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Created("", usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha))
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            return Ok("Usuário logado!");
        }
    }
}
