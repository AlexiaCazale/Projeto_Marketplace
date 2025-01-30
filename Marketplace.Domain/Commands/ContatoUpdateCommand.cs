using MediatR;

namespace Marketplace.Domain.Commands
{
    public class ContatoUpdateCommand : IRequest<string>
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
