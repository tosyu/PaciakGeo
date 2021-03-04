using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire;
using Hangfire.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaciakGeo.Hangfire.Jobs;

namespace PaciakGeo.Hangfire.Extensions
{
    public static class JobsExtensions
    {
        public static IServiceCollection RegisterJobs(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var interfaceType = typeof(IJob);
            var jobTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsInterface == false);
            
            foreach (var jobType in jobTypes.ToList())
            {
                serviceCollection.AddTransient(jobType);
                var job = serviceCollection.BuildServiceProvider().GetService(jobType);
                var name = job.GetType().Name;
                var config = configuration.GetValue<string>(name);
                RecurringJob.AddOrUpdate(name, () => ((IJob) job).Run(), config ?? Cron.Never(), TimeZoneInfo.Utc);
            }
            
            return serviceCollection;
        } 
    }
}