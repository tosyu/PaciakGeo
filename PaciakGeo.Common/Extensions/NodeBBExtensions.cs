using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaciakGeo.Common.Models.Configuration;
using PaciakGeo.Common.Repositories;

namespace PaciakGeo.Common.Extensions
{
    public static class NodeBBExtensions
    {
        public static IServiceCollection RegisterNodeBBExtensions(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddTransient<INodeBBRepository, NodeBBRepository>();
            serviceCollection.Configure<NodeBBConfig>(configuration.GetSection(nameof(NodeBBConfig)));
            serviceCollection.AddHttpClient<INodeBBRepository, NodeBBRepository>()
                .ConfigureHttpClient((serviceProvider, client) =>
                {
                    var options = serviceProvider.GetRequiredService<IOptions<NodeBBConfig>>();
                    client.BaseAddress = new Uri(options.Value.ServiceUrl);
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(options.Value.UserAgent);
                })
                .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
                {
                    UseCookies = false
                });
            
            return serviceCollection;
        }
    }
}