using System;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models;
public class Venda
{
    public int Id { get; set; }

    public int DistribuidoraId { get; set; }
    public Distribuidora distribuidora { get; set; }
    public int VendedorId { get; set; }
    public Vendedor vendedor { get; set; }
    public decimal Total { get; set; }
    public DateTime SaleDate { get; set; }
    public List<VenderItem> Items { get; set; }
}