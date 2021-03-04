using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PaciakGeo.Hangfire.Jobs
{
    public class UpsertPaciakUsersJob : IJob
    {
        private readonly ILogger<UpsertPaciakUsersJob> logger;

        public UpsertPaciakUsersJob(ILogger<UpsertPaciakUsersJob> logger)
        {
            this.logger = logger;
        }
        
        public async Task Run()
        {
            logger.LogInformation("Importing paciak users");
        }
    }
}