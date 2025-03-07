﻿using Dapper.Contrib.Extensions;

namespace Marketplace.Domain.Models
{
    [Table("Cnt_Contato")]
    public class CntContato
    {
        [Key]
        public long Codigo { get; protected set; }
        public string Nome { get;  set; } = string.Empty;
        public string Documento { get;  set; } = string.Empty;
        public string Telefone {  get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public DateTime DataRegistro { get;  set; }
        public Boolean Ativo { get;  set; }
        public string Usuario { get;  set; } = string.Empty;
        public char CodigoOperacao { get;  set; } //Foreign Key OprOperacao
    }
}
