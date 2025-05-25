using System;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models;

public class ProdutoFornecedor
{
    public int Id { get; set; }
    
    [Required]
    public int FornecedorId { get; set; }

    public Fornecedor Fornecedor { get; set; } = new();

    [Required]
    public string Nome { get; set; }= string.Empty;

    [Required]
    public string Tipo { get; set; }= string.Empty;

    [Required]
    public decimal Preco { get; set; }

    [Required]
    public int QuantidadeEstoque { get; set; }

    [Required]
    public DateTime DataValidade { get; set; }

    [Required]
    public DateTime DataCadastro { get; set; }

    
}
