using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Data;
using DistribuidoraAPI.Models;
using DistribuidoraAPI.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly AppDbContext _context;

    public FornecedorController(AppDbContext context)
    {
        _context = context;
    }

    // POST api/fornecedor/cadastro
    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarFornecedor([FromBody] CadastroFornecedorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Validação do CNPJ (14 dígitos numéricos)
        if (dto.Cnpj.Length != 14 || !long.TryParse(dto.Cnpj, out _))
            return BadRequest("CNPJ deve conter exatamente 14 dígitos numéricos.");

        // Validação do e-mail
        if (!dto.EmailCorporativo.Contains("@") || !dto.EmailCorporativo.Contains(".com"))
            return BadRequest("E-mail corporativo inválido.");

        // Criptografa a senha
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        var fornecedor = new Fornecedor
        {
            NomeEmpresa = dto.NomeEmpresa,
            Cnpj = dto.Cnpj,
            EmailCorporativo = dto.EmailCorporativo,
            Senha = dto.Senha,
            SenhaHash = senhaHash
        };

        _context.Fornecedor.Add(fornecedor);
        await _context.SaveChangesAsync();

        return Ok("Fornecedor cadastrado com sucesso.");
    }

    // GET: api/fornecedor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
    {
        return await _context.Fornecedor.ToListAsync();
    }

    // GET: api/fornecedor/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(id);

        if (fornecedor == null)
            return NotFound();

        return fornecedor;
    }

    // PUT: api/fornecedor/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
            return BadRequest();

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FornecedorExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/fornecedor/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor(int id)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(id);
        if (fornecedor == null)
            return NotFound();

        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FornecedorExists(int id)
    {
        return _context.Fornecedor.Any(e => e.Id == id);
    }
}
