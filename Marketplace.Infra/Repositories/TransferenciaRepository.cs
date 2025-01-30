using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class TransferecniaRepository: CrudRepository<TrnTransferencia, long>, ITransferenciaRepository
    {
        public TransferecniaRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

