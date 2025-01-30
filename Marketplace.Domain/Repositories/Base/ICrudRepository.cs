namespace Marketplace.Domain.Repositories.Base
{
    public interface ICrudRepository<TModel, TId>
    {
        Task<TModel> Post(TModel model);
        Task<TModel> CreateAsync(TModel model);

        Task<IEnumerable<TModel>> Get();
        Task<TModel?> GetById(TId id);
        Task Update(TId id, TModel model);
        Task UpdateAsync(TId id, TModel model);
        Task Delete(TModel model);
    }
}

//Interface genérica (abstrata) para os repositórios 