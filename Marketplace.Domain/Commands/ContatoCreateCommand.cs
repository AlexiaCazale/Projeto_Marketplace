using MediatR;

namespace Marketplace.Domain.Commands
{
    public class ContatoCreateCommand : IRequest<string>
    {
        //private readonly IContatoRepository _contatoRepository;
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; }
        public Boolean Ativo { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public char CodigoOperacao { get; set; } = 'I';

        //public ContatoCreateCommand(IContatoRepository contatoRepository, string nome, string documento, string telefone,
        //    DateTime dataRegistro, Boolean ativo, string usuario, string email, char codigoOperacao)
        //{
        //    _contatoRepository = contatoRepository;

        //   Nome = nome;
        //   Documento = documento; 
        //   Telefone = telefone;
        //   Email = email;
        //   DataRegistro = dataRegistro;
        //   Ativo = ativo;
        //   Usuario = usuario;
        //   CodigoOperacao = codigoOperacao;
        //}
    }
}
