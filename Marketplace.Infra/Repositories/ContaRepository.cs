using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class ContaRepository: CrudRepository<CtaConta, long>, IContaRepository
    {
        public ContaRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

