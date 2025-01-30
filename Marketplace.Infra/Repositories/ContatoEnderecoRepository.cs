using Marketplace.Domain.Models;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class ContatoEnderecoRepository: CrudRepository<CntEndContatoEndereco, long>, IContatoEnderecoRepository
    {
        public ContatoEnderecoRepository(IConfiguration configuration): base(configuration)
        {
        }
    }
}

