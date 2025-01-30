using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class MovimentacaoRepository: CrudRepository<CtaMovimentacao, long>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

