
namespace Marketplace.Domain.Commands
{
    public interface IRequestHandler<T>
    {
        Task<string> Handle(ContatoCreateCommand request, CancellationToken cancellationToken);
    }
}