using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace DistribuidoraAPI.Models
{
    public class Distribuidora
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeEmpresa { get; set; }= string.Empty;

        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }= string.Empty;

        [Required]
        public string EmailCorporativo { get; set; } = string.Empty;

        [Required]
        public string SenhaHash { get; set; } = string.Empty;
    }
}