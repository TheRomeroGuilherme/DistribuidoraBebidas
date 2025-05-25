using System;

namespace DistribuidoraAPI.Models.DTOs;

public class CadastroProdutoDto
{
    public string Nome { get; set; }= string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public DateTime DataValidade { get; set; }
    public int FornecedorId { get; set; }
}
