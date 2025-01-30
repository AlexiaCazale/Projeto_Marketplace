using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("End_UnidadeFederativa")]
    public class EndUnidadeFederativa
    {
        [Key] //Autoincremento

        public long Codigo { get; protected set; }

        //private long _codigo;
        //public long GetCodigo
        //{
        //    return _codigo;
        //}
        //public void SetCodigo(long codigo)
        //{
        //    _codigo = codigo;   
        //}

        public string Descricao { get;  set; } = string.Empty;
        public string Sigla { get;  set; } = string.Empty;
    }
}
