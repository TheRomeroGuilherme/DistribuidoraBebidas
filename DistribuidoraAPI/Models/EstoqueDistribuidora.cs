using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DistribuidoraAPI.Models.DTOs;
using DistribuidoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAPI.Models;

public class EstoqueDistribuidora
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal PrecoVenda { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataValidade { get; set; }
    public DateTime DataCadastro { get; set; }
}
