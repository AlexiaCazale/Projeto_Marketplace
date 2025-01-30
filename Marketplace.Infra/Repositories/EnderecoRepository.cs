using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class EnderecoRepository: CrudRepository<EndEndereco, long>, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

