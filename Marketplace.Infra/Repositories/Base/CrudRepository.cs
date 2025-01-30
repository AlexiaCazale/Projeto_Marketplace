using Dapper;
using Dapper.Contrib.Extensions;
using Marketplace.Domain.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Marketplace.Infra.Repositories.Base
{

    //Comunicação com o banco de dados
    //Classe abstrata
    public abstract class CrudRepository<TModel, TId> : ICrudRepository<TModel, TId> where TModel : class
    {
        private readonly IDbConnection _connection;
        private readonly string _query = $"Select * From {TableName()}";

        public CrudRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            _connection = new SqlConnection(connectionString);
        }

        private static string TableName()
        {
            return typeof(TModel).GetCustomAttribute<TableAttribute>(false)?.Name ?? throw new ArgumentException("Entity must have one [Table] property");
        }

        public static string FieldKey()
        {
            var key = typeof(TModel).GetProperties().Where(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0).FirstOrDefault();
            if (key == null)
                key = typeof(TModel).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExplicitKeyAttribute), true).Length > 0).FirstOrDefault();

            if (key == null)
                throw new ArgumentException("Entity must have one [Key] or [ExplicitKey] property");

            return key.Name;
        }

        public virtual async Task<TModel> Post(TModel model)
        {
            await _connection.InsertAsync(model);
            return model;
        }

        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            await _connection.InsertAsync(model);
            return model;
        }

        public virtual Task<IEnumerable<TModel>> Get()
        {
            return _connection.QueryAsync<TModel>(_query);
        }

        public virtual Task<TModel?> GetById(TId id)
        {
            var query = $"{_query} Where {FieldKey()} = @Id";

            return _connection.QuerySingleOrDefaultAsync<TModel?>(query, new { id });
        }

        public virtual Task<TModel?> GetByIdInfraQuery(TId id)
        {
            var query = $"{_query} Where {FieldKey()} = @Id";

            return _connection.QuerySingleOrDefaultAsync<TModel?>(query, new { id });
        }

        public virtual async Task UpdateAsync(TId id, TModel model)
        {
            await _connection.UpdateAsync(model);
        }

        public virtual async Task Update(TId id, TModel model)
        {
            await _connection.UpdateAsync(model);
        }

        public virtual async Task Delete(TModel model)
        {
            await _connection.DeleteAsync(model);
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            await _connection.DeleteAsync(model);
        }

    }
}
