using System;

namespace DistribuidoraAPI.Models.DTOs;

public class CadastrarClienteDto
{
    public string Nome { get; set; }= string.Empty;
    public string Email { get; set; }= string.Empty;
    public string Senha { get; set; }= string.Empty;
}
