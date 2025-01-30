using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class TransacaoRepository: CrudRepository<TrnTransacao, long>, ITransacaoRepository
    {
        public TransacaoRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

