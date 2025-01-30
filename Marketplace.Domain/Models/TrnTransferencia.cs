using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Trn_Transferencia")]
    public class TrnTransferencia
    {
        [Key]
        public long Codigo { get; protected set; }
        public string ArquivoLink { get;  set; } = string.Empty;
        public decimal Quantidade { get;  set; } 
        public DateTime DataRegistro { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoTipoTransferencia { get;  set; }
        public long CodigoContaOrigem { get;  set; }
        public long CodigoContaDestino { get;  set; }
        public char CodigoOperacao { get;  set; }

    }
}
