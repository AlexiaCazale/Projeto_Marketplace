using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class TransacaoTransferenciaRepository: CrudRepository<TrnTransacaoTransferencia, long>, ITransacaoTransferenciaRepository
    {
        public TransacaoTransferenciaRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

