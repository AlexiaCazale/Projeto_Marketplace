using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Cta_Conta")]    
    public class CtaConta
    {
        [Key]
        public long Codigo { get; protected set; }
        public string Descricao { get;  set; } = string.Empty;
        public decimal Saldo { get;  set; }
        public DateTime DataRegisto { get;  set; } //Registo
        public string Usuario { get;  set; } = string.Empty;
        public long CodigoSuperior { get;  set; }
        public long CodigoContato { get;  set; }
        public char CodigoOperacao { get;  set; } 
    }
}
