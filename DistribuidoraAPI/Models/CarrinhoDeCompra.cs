using System;

namespace DistribuidoraAPI.Models;

public class CarrinhoDeCompra
{
    public int Id { get; set; }
    public int DistribuidoraId { get; set; }
    public Distribuidora Distribuidora { get; set; } = new Distribuidora();

    public int ProdutoId { get; set; }
    public Produto ProdutoItem { get; set; } 

    public int Quantidade { get; set; }
}

