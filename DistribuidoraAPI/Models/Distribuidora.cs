using System;

namespace DistribuidoraAPI.Models;

public class Distribuidora
{
    public int Id { get; set; }
    public string Email { get; set; }= string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public List<CarrinhoDeCompra> CarrinhoItems { get; set; } = new();
}
