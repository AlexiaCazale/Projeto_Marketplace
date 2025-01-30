using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Marketplace.Domain.Commands;
using Marketplace.Domain.Models;
using Marketplace.Domain.Querys;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infra.Repositories
{
    public class ContatoRepository : CrudRepository<CntContato, long>, IContatoRepository
    {
        private readonly IDbConnection _connection;
        public ContatoRepository(IConfiguration configuration) : base(configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            _connection = new SqlConnection(connectionString);
        }
        public async Task<ContatoInfraQuery> GetByIdInfraQuery(long id)
        {
            var query = "SELECT Codigo, " +
                "Nome, " +
                "Documento, " +
                "Telefone, " +
                "DataRegistro, " +
                "Ativo, " +
                "Usuario, " +
                "Email " +
                "FROM Cnt_Contato " +
                "WHERE Codigo = @Id";

            var result = await _connection.QuerySingleOrDefaultAsync<ContatoInfraQuery>(query, new { id });

            return result;
        }

        //public async Task<ContatoQuery?> CreateAsync(ContatoCreateCommand request)
        //{
        //    var query = @"
        //        INSERT INTO Cnt_Contato (
        //            Nome, 
        //            Documento, 
        //            Telefone, 
        //            DataRegistro, 
        //            Ativo, 
        //            Usuario, 
        //            Email,
        //            CodigoOperacao
        //        )
        //        VALUES (
        //            @Nome, 
        //            @Documento, 
        //            @Telefone, 
        //            @DataRegistro, 
        //            @Ativo, 
        //            @Usuario, 
        //            @Email,
        //            @CodigoOperacao
        //        )";

        //    var parameters = new
        //    {
        //        request.Nome,
        //        request.Documento,
        //        request.Telefone,
        //        request.DataRegistro,
        //        request.Ativo,
        //        request.Usuario,
        //        request.Email,
        //        request.CodigoOperacao
        //    };

        //    await _connection.ExecuteAsync(query, parameters);

        //    var selectQuery = "SELECT * FROM Cnt_Contato WHERE Codigo = @Id";

        //    var createdContato = await _connection.QuerySingleOrDefaultAsync<ContatoQuery>(selectQuery, );

        //    return createdContato;
        //}

        //public async Task<ContatoQuery> UpdateAsync(long id, ContatoUpdateCommand request)
        //{
        //    var query = @"
        //        UPDATE Cnt_Contato SET
        //            Nome = @Nome, 
        //            Telefone = @Telefone,
        //            Email = @Email
        //        WHERE Codigo = @Id";

        //    var parameters = new
        //    {
        //        Nome = request.Nome,
        //        Telefone = request.Telefone,
        //        Email = request.Email,
        //        Id = id
        //    };

        //    await _connection.ExecuteAsync(query, parameters);

        //    var selectQuery = "SELECT Codigo, Nome, Telefone, Email FROM Cnt_Contato WHERE Codigo = @Id";
        //    var updatedContato = await _connection.QuerySingleOrDefaultAsync<ContatoQuery>(selectQuery, new { Id = id });

        //    return updatedContato;
        //}
    }
}

