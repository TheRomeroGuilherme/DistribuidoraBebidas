using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models.DTOs;

namespace DistribuidoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // ROTA DE LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha);

            if (!senhaCorreta)
                return Unauthorized("Senha inválida");

            return Ok(new { usuario.Id, usuario.Nome, usuario.Email });
        }
    }
}
