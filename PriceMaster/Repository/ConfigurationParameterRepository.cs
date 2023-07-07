using Dapper;
using PriceMaster.Models;
using System.Data;
using System.Data.SqlClient;

namespace PriceMaster.Repository
{
    public class ConfigurationParameterRepository : IConfiguratonParameterRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public ConfigurationParameterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("PriceMasterConnectionString") ?? string.Empty;
        }
        
        public IEnumerable<ConfigurationParameter> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                string query = "SELECT * FROM [dbo].[ConfigurationParameters]";
                return connection.Query<ConfigurationParameter>(query).ToList();
            }
        }

        public ConfigurationParameter GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                string query = "SELECT * FROM [dbo].[ConfigurationParameters] WHERE [Id] = @Id";
                return connection.QueryFirstOrDefault<ConfigurationParameter>(query, new { Id = id });
            }
        }

        public void Insert(ConfigurationParameter parameter)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                string query = @"
                INSERT INTO [dbo].[ConfigurationParameters]
                ([IVA], [ScortaMinima], [RicaricoMinimo], [SpeseSpedizioneListino], [MargineSSMinimo],
                [DifferenzaMinima], [SpeseSpedizioneRivenditore], [ValidFrom], [ValidTo], [IsCurrent], [CreatedAt], [UpdatedAt])
                VALUES
                (@IVA, @ScortaMinima, @RicaricoMinimo, @SpeseSpedizioneListino, @MargineSSMinimo,
                @DifferenzaMinima, @SpeseSpedizioneRivenditore, @ValidFrom, @ValidTo, @IsCurrent, @CreatedAt, @UpdatedAt)";

                connection.Execute(query, parameter);
            }
        }

        public void Update(ConfigurationParameter parameter)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                string query = @"
                UPDATE [dbo].[ConfigurationParameters]
                SET [IVA] = @IVA, [ScortaMinima] = @ScortaMinima, [RicaricoMinimo] = @RicaricoMinimo, [SpeseSpedizioneListino] = @SpeseSpedizioneListino,
                [MargineSSMinimo] = @MargineSSMinimo, [DifferenzaMinima] = @DifferenzaMinima, [SpeseSpedizioneRivenditore] = @SpeseSpedizioneRivenditore,
                [ValidFrom] = @ValidFrom, [ValidTo] = @ValidTo, [IsCurrent] = @IsCurrent, [CreatedAt] = @CreatedAt, [UpdatedAt] = @UpdatedAt
                WHERE [Id] = @Id";

                connection.Execute(query, parameter);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                string query = "DELETE FROM [dbo].[ConfigurationParameters] WHERE [Id] = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

    }
}
