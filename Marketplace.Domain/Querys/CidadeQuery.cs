using System.Globalization;

namespace Marketplace.Domain.Querys
{
    public class CidadeQuery
    {
        public long Codigo { get; protected set; }
        public string Descricao { get; set; } = string.Empty;
        public long CodigoUF { get; set; }
        public string SiglaUF { get; set; } = string.Empty;
        public string DescricaoUF {  get; set; } = string.Empty;

        //Sem query em infra
        public UnidadeFederativaQuery UnidadeFederativa { get; set; } = new UnidadeFederativaQuery();
    } 
    public class UnidadeFederativaQuery
    {
        public long Codigo { get; set; }
        public string Sigla { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;   
    }
}
