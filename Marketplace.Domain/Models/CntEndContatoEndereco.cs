using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Cnt_End_Contato_Endereco")]
    public class CntEndContatoEndereco
    {
        [ExplicitKey]
        public long Codigo { get; protected set; }
        public DateTime DataRegistro { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoContato { get;  set; }   
        public long CodigoEndereco { get;  set; }
        public char CodigoOperacao { get;  set; }
        public string Descricao { get; internal set; }
    }
}
