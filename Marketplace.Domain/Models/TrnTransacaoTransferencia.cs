using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Trn_TransacaoTransferencia")]
    public class TrnTransacaoTransferencia
    {
        [Key]
        public long Codigo { get; protected set; }
        public DateTime DataRegistro { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoTransacao { get;  set; }
        public long CodigoTransferencia { get;  set; }
        public char CodigoOperacao { get;  set; }
    }
}
