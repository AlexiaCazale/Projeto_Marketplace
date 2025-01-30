using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Trn_TipoTransferencia")]
    public class TrnTipoTransferencia
    {
        //[Key] - a tabela não é autoincremento 

        [ExplicitKey]
        public long Codigo { get; protected set; }
        public string Descricao { get;  set; } = string.Empty;
    }
}
