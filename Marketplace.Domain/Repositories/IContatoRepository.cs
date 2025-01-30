using Marketplace.Domain.Commands;
using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories.Base;

namespace Marketplace.Domain.Repositories
{
    public interface IContatoRepository : ICrudRepository<CntContato, long>
    {
        Task<ContatoInfraQuery?> GetByIdInfraQuery(long id);
        //Task<ContatoQuery> CreateAsync(ContatoCreateCommand request);
        //Task<ContatoQuery> UpdateAsync(long id, ContatoUpdateCommand request); 
    }
}
