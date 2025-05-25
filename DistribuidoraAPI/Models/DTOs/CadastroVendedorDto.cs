using System;

namespace DistribuidoraAPI.Model;

public class CadastroVendedor
{
    public string NomeLoja { get; set; }= string.Empty;
    public string CNPJ { get; set; }= string.Empty;
    public string Senha { get; set; }= string.Empty;
}
