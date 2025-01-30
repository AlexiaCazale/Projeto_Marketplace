using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class TipoTransferenciaRepository: CrudRepository<TrnTipoTransferencia, long>, ITipoTransferenciaRepository
    {
        public TipoTransferenciaRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

