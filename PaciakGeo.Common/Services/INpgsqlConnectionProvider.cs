using Npgsql;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Services
{
    public interface INpgsqlConnectionProvider
    {
        NpgsqlConnection GetConnection(DbType dbType);
    }
}