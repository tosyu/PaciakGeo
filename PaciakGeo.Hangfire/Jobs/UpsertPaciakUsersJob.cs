using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;
using PaciakGeo.Common.Services;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.Hangfire.Jobs
{
    // ReSharper disable once UnusedType.Global
    public class UpsertPaciakUsersJob : IJob
    {
        private readonly ILogger<UpsertPaciakUsersJob> logger;
        private readonly INodeBBUsersService nodeBBUsersService;
        private readonly IUserRepository userRepository;

        public UpsertPaciakUsersJob(ILogger<UpsertPaciakUsersJob> logger, INodeBBUsersService nodeBBUsersService, IUserRepository userRepository)
        {
            this.logger = logger;
            this.nodeBBUsersService = nodeBBUsersService;
            this.userRepository = userRepository;
        }
        
        public async Task Run()
        {
            logger.LogInformation("Fetching users");
            var paciakUsers = await nodeBBUsersService.GetUsers();

            foreach (var paciakUser in paciakUsers)
            {
                var user = new User
                {
                    Uid = paciakUser.Uid,
                    Name = paciakUser.Slug,
                    Location = paciakUser.Location,
                    AvatarUrl = paciakUser.Picture
                };

                logger.LogInformation($"Upserting user {user.Name}");
                await userRepository.Upsert(user);
            }
        }
    }
}