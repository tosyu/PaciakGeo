using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.Common.Repositories;

namespace PaciakGeo.Common.Extensions
{
    public static class LocationExtensions
    {
        public static IServiceCollection RegisterLocationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILocationRepository, LocationRepostory>();
            
            return serviceCollection;
        }
    }
}