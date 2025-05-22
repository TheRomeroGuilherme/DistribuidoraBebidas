using System;

namespace DistribuidoraAPI.Models;

public class CarrinhoDeCompra
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int ProdutoId { get; set; }
    public Produto ProdutoItem { get; set; }

    public int Quantidade { get; set; }
}

