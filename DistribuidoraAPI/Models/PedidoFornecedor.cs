using System;

namespace DistribuidoraAPI.Models;

public class PedidoFornecedor
{
    public int Id { get; set; }

    public int DistribuidoraId { get; set; }
    public Distribuidora Distribuidora { get; set; }

    public int ProdutoFornecedorId { get; set; }
    public ProdutoFornecedor ProdutoFornecedor { get; set; }

    public int Quantidade { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
}
