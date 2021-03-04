using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;

namespace PaciakGeo.WebApi.Services
{
    public class UsersService : IUsersService
    {
        private readonly INodeBBRepository repository;
        private readonly ILocationRepository locationRepository;

        public UsersService(INodeBBRepository repository, ILocationRepository locationRepository)
        {
            this.repository = repository;
            this.locationRepository = locationRepository;
        }

        public async Task<IEnumerable<PaciakUser>> GetUsers()
        {
            var users = await repository.GetUsers();
            var usersWithLocation = (await repository.GetUsers(users.Select(user => user.Slug).ToArray()))
                .Where(p => !string.IsNullOrEmpty(p.Location)).ToList();
            var usersWithCoordinates = await Task.WhenAll(usersWithLocation.Select(GetCoordinates));

            return usersWithCoordinates.ToList();
        }
        
        private async Task<PaciakUser> GetCoordinates(PaciakUser user)
        {
            user.Coordinates = await locationRepository.FindLocationCoordinates(user.Location);
            return user;
        }
    }
}