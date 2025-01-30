using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("End_Endereco")]
    public class EndEndereco
    {
        [Key]
        public long Codigo { get; protected set; }
        public string Bairro { get;  set; } = string.Empty;
        public string Logradouro { get;  set; } = string.Empty;
        public string CEP { get;  set; } = string.Empty;
        public string Numero { get;  set; } = string.Empty;
        public string Referencia { get;  set; } = string.Empty;
        public DateTime DataRegistro { get;  set; } 
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoContato { get;  set; }
        public long CodigoCidade { get;  set; }
        public char CodigoOperacao { get;  set; }
    }
}
