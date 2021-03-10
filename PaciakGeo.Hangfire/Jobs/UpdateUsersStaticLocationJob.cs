using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaciakGeo.Common.Repositories;
using PaciakGeo.Common.Services;

namespace PaciakGeo.Hangfire.Jobs
{
    public class UpdateUsersStaticLocationJob : IJob
    {
        private readonly ILogger<UpdateUsersStaticLocationJob> logger;
        private readonly IUserService userService;

        public UpdateUsersStaticLocationJob(ILogger<UpdateUsersStaticLocationJob> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }
        
        public async Task Run()
        {
            logger.LogInformation("Updating user coordinate location");
            var users = await userService.GetUsersForLocationUpdate(25);
            foreach (var user in users)
            {
                await userService.UpdateUserLocationCoordinates(user);
            }
        }
    }
}