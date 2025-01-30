using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class OperacaoRepository: CrudRepository<OprOperacao, char>, IOperacaoRepository
    {
        public OperacaoRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

