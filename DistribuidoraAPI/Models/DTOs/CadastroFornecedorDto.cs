using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuidoraAPI.Models.DTOs
{
    public class CadastroFornecedorDto
    {
        public string NomeEmpresa { get; set; } = string.Empty;

        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter 14 dígitos.")]
        public string? Cnpj { get; set; }

        [EmailAddress(ErrorMessage = "E-mail corporativo inválido.")]
        public string EmailCorporativo { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public List<CadastroProdutoDto> ProdutosFornecedor { get; set; } = new();
        
    }
}


