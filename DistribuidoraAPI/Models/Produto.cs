using System;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }= string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; } = new();
    }
}
