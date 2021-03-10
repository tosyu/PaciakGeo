using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;
using PaciakGeo.Common.Services;

namespace PaciakGeo.WebApi.Services
{
    public class NodeBBUsersService : INodeBBUsersService
    {
        private readonly INodeBBRepository repository;
        private readonly ILocationRepository locationRepository;

        public NodeBBUsersService(INodeBBRepository repository, ILocationRepository locationRepository)
        {
            this.repository = repository;
            this.locationRepository = locationRepository;
        }

        public async Task<IEnumerable<PaciakUser>> GetUsers()
        {
            var users = await repository.GetUsers();
            var usersWithLocation = (await repository.GetUsers(users.Select(user => user.Slug).ToArray()))
                .Where(p => !string.IsNullOrEmpty(p.Location));

            return usersWithLocation.ToList();
        }
    }
}