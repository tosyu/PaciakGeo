using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.Common.Services;

namespace PaciakGeo.Common.Extensions
{
    public static class NpgsqlExtensions
    {
        public static IServiceCollection RegisterNpgsqlExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INpgsqlConnectionProvider, NpgsqlConnectionProvider>();
            return serviceCollection;
        }
    }
}