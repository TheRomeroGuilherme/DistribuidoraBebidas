using System;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models;

public class Vendedor
{
    public int Id { get; set; }
    public string NomeLoja { get; set; }
    public string CNPJ { get; set; }
    public string SenhaHash { get; set; }
    public List<Produto> ProdutoItem { get; set; }
}
