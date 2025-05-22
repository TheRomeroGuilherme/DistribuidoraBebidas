using System;

namespace DistribuidoraAPI.Models;
public class Venda
{
    public int Id { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
 
    public int VendedorId { get; set; }
    public Vendedor vendedor { get; set; }

    public decimal Total { get; set; }

    public DateTime SaleDate { get; set; }
    public List<VenderItem> Items { get; set; }
}