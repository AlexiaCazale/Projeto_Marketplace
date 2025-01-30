using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;
using Marketplace.Domain.Services;
using MediatR;

namespace Marketplace.Domain.Commands
{
    internal class ContatoUpdateCommandHandler : IRequestHandler<ContatoUpdateCommand, string>
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ContatoService _contatoService;
        private readonly IMediator _mediator;

        public ContatoUpdateCommandHandler(IContatoRepository contatoRepository, ContatoService contatoService, IMediator mediator)
        {
            _contatoRepository = contatoRepository;
            _contatoService = contatoService;
            _mediator = mediator;
        }

        public async Task<string> Handle(ContatoUpdateCommand request, CancellationToken cancellationToken)
        {
            var contato = new ContatoInfraQuery
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email
            };

            return contato.Codigo.ToString();
        }
    }
}
