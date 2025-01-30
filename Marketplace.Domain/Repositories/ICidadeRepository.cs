using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories.Base;

namespace Marketplace.Domain.Repositories
{
    public interface ICidadeRepository : ICrudRepository<EndCidade, long>
    {
        //Task<CidadeQuery> GetByIdQuery(long id);
        Task<CidadeInfraQuery> GetByIdInfraQuery(long id);

    }
}
