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
    public string? NomeProdutoFornecedor { get; set; }

    [Required]
    public int UnidadeLoteFornecedor { get; set; }

    [Required]
    public decimal ValorLoteFornecedor { get; set; }

    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }
}
