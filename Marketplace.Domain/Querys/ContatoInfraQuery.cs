namespace Marketplace.Domain.Querys
{
    public class ContatoInfraQuery
    {
        public long Codigo { get; protected set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
        public Boolean Ativo { get; set; }
        public string Usuario { get; set; } = string.Empty;
    }
}
