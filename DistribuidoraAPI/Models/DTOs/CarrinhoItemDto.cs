using System;

namespace DistribuidoraAPI.Model;

public class CarrinhoItemDto
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public float TotalValor { get; set; }
}
