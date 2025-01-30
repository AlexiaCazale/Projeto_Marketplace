using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Opr_Operacao")]
    public class OprOperacao
    {
        [ExplicitKey]
        public char Codigo { get; protected set; } //Tipo char(1)
        public string Descricao { get;  set; } = string.Empty;
    }
}
