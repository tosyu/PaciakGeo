using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;

namespace PaciakGeo.Common.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository userRepository;
        private readonly ILocationRepository locationRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository, ILocationRepository locationRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.locationRepository = locationRepository;
        }
        
        public async Task<IEnumerable<User>> GetUsersForLocationUpdate(int? limit)
        {
            return await userRepository.GetUsersForLocationUpdate(limit);
        }

        public async Task<bool> UpdateUserLocationCoordinates(User user)
        {
            logger.LogDebug($"Updating user {user.Uid} location");

            var coords = await locationRepository.FindLocationCoordinates(user.Location);

            user.LocationLatitude = coords.Latitude;
            user.LocationLongitude = coords.Longitude;

            return await userRepository.Upsert(user);
        }
    }
}