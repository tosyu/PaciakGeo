using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Services
{
    public interface INodeBBUsersService
    {
        Task<IEnumerable<PaciakUser>> GetUsers();
    }
}