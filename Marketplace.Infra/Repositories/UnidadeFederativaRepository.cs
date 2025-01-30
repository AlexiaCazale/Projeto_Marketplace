using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class UnidadeFederativaRepository: CrudRepository<EndUnidadeFederativa, long>, IUnidadeFederativaRepository
    {
        public UnidadeFederativaRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

