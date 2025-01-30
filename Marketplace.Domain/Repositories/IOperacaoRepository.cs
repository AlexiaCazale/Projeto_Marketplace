using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories.Base;

namespace Marketplace.Domain.Repositories
{
    public interface IOperacaoRepository : ICrudRepository<OprOperacao, char>
    {
    }
}

