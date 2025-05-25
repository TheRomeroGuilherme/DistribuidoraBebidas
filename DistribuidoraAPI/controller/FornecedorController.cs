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
            SenhaHash = senhaHash
        };

        _context.Fornecedor.Add(fornecedor);
        await _context.SaveChangesAsync();

        if (dto.ProdutosFornecedor != null && dto.ProdutosFornecedor.Count > 0)
        {
            foreach (var produtoDto in dto.ProdutosFornecedor)
            {
                var produto = new ProdutoFornecedor
                {
                    Nome = produtoDto.Nome,
                    Tipo = produtoDto.Tipo,
                    Preco = produtoDto.Preco,
                    QuantidadeEstoque = produtoDto.QuantidadeEstoque,
                    DataValidade = produtoDto.DataValidade,
                    DataCadastro = DateTime.Now,
                    FornecedorId = fornecedor.Id
                };

                _context.ProdutosFornecedor.Add(produto);
            }

            await _context.SaveChangesAsync();
        }

        return Ok("Fornecedor e produtos cadastrados com sucesso.");
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
        var fornecedor = await _context.Fornecedor
            .Include(f => f.ProdutoFornecedor)
            .FirstOrDefaultAsync(f => f.Id == id);

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
        var fornecedor = await _context.Fornecedor
            .Include(f => f.ProdutoFornecedor)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (fornecedor == null)
            return NotFound();

        _context.ProdutosFornecedor.RemoveRange(fornecedor.ProdutoFornecedor);
        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FornecedorExists(int id)
    {
        return _context.Fornecedor.Any(e => e.Id == id);
    }

    // --- Novo endpoint para cadastrar lote de produtos (bebidas ou insumos) ---

    [HttpPost("{fornecedorId}/produtos")]
    public async Task<IActionResult> CadastrarProdutoNoFornecedor(int fornecedorId, [FromBody] CadastroProdutoDto dto)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(fornecedorId);
        if (fornecedor == null)
            return NotFound("Fornecedor não encontrado.");

        var produto = new ProdutoFornecedor
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            Preco = dto.Preco,
            QuantidadeEstoque = dto.QuantidadeEstoque,
            DataValidade = dto.DataValidade,
            DataCadastro = DateTime.Now,
            FornecedorId = fornecedorId
        };

        _context.ProdutosFornecedor.Add(produto);
        await _context.SaveChangesAsync();

        return Ok(produto);
    }

    // --- Listagem de produtos Fornecedor 
    // GET: api/fornecedor/1/produtos
    [HttpGet("{id}/produtos")]
    public async Task<IActionResult> GetProdutosDoFornecedor(int id)
    {
        var fornecedor = await _context.Fornecedor
            .Include(f => f.ProdutoFornecedor)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (fornecedor == null)
            return NotFound(new { mensagem = "Fornecedor não encontrado." });

        return Ok(fornecedor.ProdutoFornecedor);
    }
}
