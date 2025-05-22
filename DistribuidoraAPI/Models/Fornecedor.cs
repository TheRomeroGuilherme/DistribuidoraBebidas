using System;

namespace DistribuidoraAPI.Models;

public class Fornecedor
{
    public int Id { get; set; }
    public string NomeEmpresa { get; set; }
    
    public string CNPJ { get; set; }

    public string SenhaHash { get; set; }
    public List<Produto> ProdutoItem { get; set; }
}
