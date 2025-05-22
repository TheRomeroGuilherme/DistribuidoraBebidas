using System;

namespace DistribuidoraAPI.Model;

public class LoginDto
{
    public string EmailOrCNPJ { get; set; }
    public string Senha { get; set; }
}
