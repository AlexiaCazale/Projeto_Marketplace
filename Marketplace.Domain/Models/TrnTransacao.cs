using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Trn_Transacao")]
    public class TrnTransacao
    {
        [ExplicitKey] //Usado quando eu manipulo o código
        public long Codigo { get; protected set; }
        public DateTime DataMovimento { get;  set; }
        public decimal Quantidade { get;  set; }
        public decimal Saldo { get;  set; }
        public DateTime DataRegistro { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoContaOrigem { get;  set; }
        public long CodigoContaDestino { get;  set; }
        public char CodigoOperacao { get;  set; }
    }
}
    