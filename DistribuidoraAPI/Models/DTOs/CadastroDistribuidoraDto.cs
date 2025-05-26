using System;

namespace DistribuidoraAPI.DTOs
{
    public class DistribuidoraCadastroDto
    {
        public string NomeEmpresa { get; set; }= string.Empty;
        public string Cnpj { get; set; }= string.Empty;
        public string EmailCorporativo { get; set; }= string.Empty;
        public string Senha { get; set; }= string.Empty;
    }
}
