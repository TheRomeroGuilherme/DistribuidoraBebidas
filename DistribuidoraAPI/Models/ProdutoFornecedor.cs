using System;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models;

public class ProdutoFornecedor
{
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Tipo { get; set; }

    [Required]
    public decimal Preco { get; set; }

    [Required]
    public int QuantidadeEstoque { get; set; }

    [Required]
    public DateTime DataValidade { get; set; }

    [Required]
    public DateTime DataCadastro { get; set; }

    [Required]
    public int FornecedorId { get; set; }

    public Fornecedor Fornecedor { get; set; }
}
