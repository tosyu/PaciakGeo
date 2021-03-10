using Microsoft.Extensions.Configuration;
using Npgsql;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Services
{
    public class NpgsqlConnectionProvider : INpgsqlConnectionProvider
    {
        private readonly IConfiguration configuration;

        public NpgsqlConnectionProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public NpgsqlConnection GetConnection(DbType dbType)
        {
            return new(configuration.GetConnectionString(dbType.ToString()));
        }
    }
}