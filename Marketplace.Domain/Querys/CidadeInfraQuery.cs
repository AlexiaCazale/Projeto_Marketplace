namespace Marketplace.Domain.Querys
{
    public class CidadeInfraQuery
    {
        public long Codigo { get; protected set; }
        public string Descricao { get; set; } = string.Empty;
        public long CodigoUF { get; set; }
        public string SiglaUF { get; set; } = string.Empty;
        public string DescricaoUF { get; set; } = string.Empty;
    }
}