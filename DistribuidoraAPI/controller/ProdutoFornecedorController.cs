using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFornecedorController : ControllerBase
    {
    private readonly AppDbContext _context;

    public ProdutoFornecedorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarProduto(CadastroProdutoDto dto)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(dto.FornecedorId);
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
            FornecedorId = dto.FornecedorId
        };

        _context.ProdutosFornecedor.Add(produto);
        await _context.SaveChangesAsync();

        return Ok(produto);
    }
}
