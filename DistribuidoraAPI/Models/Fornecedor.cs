using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        public string NomeEmpresa { get; set; } = string.Empty;

        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter 14 dígitos.")]
        public string Cnpj { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "E-mail corporativo inválido.")]
        public string EmailCorporativo { get; set; } = string.Empty;

        [Required]
        public string SenhaHash { get; set; } = string.Empty;

        public List<ProdutoFornecedor> ProdutoFornecedor { get; set; } = new();
    }
}
