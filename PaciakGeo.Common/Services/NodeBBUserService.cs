using System.Threading.Tasks;
using PaciakGeo.Common.Models;
using PaciakGeo.Common.Repositories;

namespace PaciakGeo.Common.Services
{
    public class NodeBBUserService : INodeBBUserService
    {
        private readonly INodeBBRepository nodeBbRepository;

        public NodeBBUserService(INodeBBRepository nodeBbRepository)
        {
            this.nodeBbRepository = nodeBbRepository;
        }

        public async Task<PaciakUser> GetUserBySessionId(string sessionId)
        {
            return await nodeBbRepository.GetUserBySessionId(sessionId);
        }
    }
}