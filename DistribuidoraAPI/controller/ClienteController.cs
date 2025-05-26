using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models;
using DistribuidoraAPI.Models.DTOs;

namespace DistribuidoraAPI.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public ClienteController(AppDbContext context, TokenService tokenService, IConfiguration configuration)
        {
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        // POST api/cliente/cadastro
        [HttpPost("cadastro")]
        public IActionResult Cadastro([FromBody] CadastrarClienteDto clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Dados do cliente não informados.");

            if (string.IsNullOrEmpty(clienteDto.Email) || string.IsNullOrEmpty(clienteDto.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            var existente = _context.Clientes.FirstOrDefault(c => c.Email == clienteDto.Email);
            if (existente != null)
                return Conflict("Cliente já cadastrado com este email.");

            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                SenhaHash = clienteDto.Senha // Recomendo hash depois
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Cadastro), new { id = cliente.Id }, cliente);
        }

        // POST api/cliente/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == login.Email);

            if (cliente == null || cliente.SenhaHash != login.Senha)
                return Unauthorized();

            var secretKey = _configuration["Jwt:Key"];
            var token = TokenService.GerarToken(cliente.Email, "Cliente", secretKey);

            return Ok(new { token });
        }
    }
}
