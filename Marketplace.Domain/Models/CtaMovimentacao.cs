using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Cta_Movimentacao")]
    public class CtaMovimentacao
    {
        [Key]
        public long Codigo { get; protected set; }
        public DateTime DataMovimento { get;  set; }
        public decimal Quantidade { get;  set; }
        public DateTime DataRegistro { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoTransacao { get;  set; }
        public long CodigoConta { get;  set; }   
        public char CodigoOperacao { get;  set; }
    }
}
