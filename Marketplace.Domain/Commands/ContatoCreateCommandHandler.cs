using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;
using Marketplace.Domain.Services;
using MediatR;


namespace Marketplace.Domain.Commands
{
    internal class ContatoCreateCommandHandler : IRequestHandler<ContatoCreateCommand, string>
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ContatoService _contatoService;
        private readonly IMediator _mediator;

        public ContatoCreateCommandHandler(IContatoRepository contatoRepository, ContatoService contatoService, IMediator mediator)
        {
            _contatoRepository = contatoRepository;
            _contatoService = contatoService;
            _mediator = mediator;
        }
        public async Task<string> Handle(ContatoCreateCommand request, CancellationToken cancellationToken)
        {
            var contato = new ContatoQuery
            {
                Nome = request.Nome,
                Documento = request.Documento,
                Telefone = request.Telefone,
                Email = request.Email,
                DataRegistro = request.DataRegistro,
                Ativo = request.Ativo,
                Usuario = request.Usuario,
            };

            return contato.Codigo.ToString(); 
        }

    }
}