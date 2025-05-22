using System;

namespace DistribuidoraAPI.Models;

public class Cliente
{
    public int Id { get; set; }
 
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public List<CarrinhoDeCompra> CarrinhoItems { get; set; }
}
