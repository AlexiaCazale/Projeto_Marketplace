using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("End_Cidade")]
    public class EndCidade
    {
        [Key]
        public long Codigo { get; protected set; }
        public long CodigoEstado { get;  set; } //Foreign key de UnidadeFederativa
        public string Descricao { get;  set; } = string.Empty;
    }
}
