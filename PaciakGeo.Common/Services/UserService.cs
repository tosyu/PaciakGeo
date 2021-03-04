using System.Threading.Tasks;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.Common.Services
{
    public class UserService : IUserService
    {
        private readonly INodeBBRepository nodeBbRepository;

        public UserService(INodeBBRepository nodeBbRepository)
        {
            this.nodeBbRepository = nodeBbRepository;
        }

        public async Task<PaciakUser> GetUserBySessionId(string sessionId)
        {
            return await nodeBbRepository.GetUserBySessionId(sessionId);
        }
    }
}