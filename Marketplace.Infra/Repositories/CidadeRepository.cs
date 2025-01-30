using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class CidadeRepository : CrudRepository<EndCidade, long>, ICidadeRepository
    {
        public CidadeRepository(IConfiguration configuration): base(configuration)
        {
        }

        public Task<CidadeInfraQuery> GetByIdInfraQuery(long id)
        {
            throw new NotImplementedException();
        }
    }
}

