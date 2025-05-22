using System;

namespace DistribuidoraAPI.Models;

public class Produto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal PrecoLote { get; set; }
    public int Quantidade { get; set; }
    public int? FornecedorId { get; set; }
    public Fornecedor fornecedorItem { get; set; }
    public int? VendedorId { get; set; }
    public Vendedor Vendedoritem { get; set; }
}
