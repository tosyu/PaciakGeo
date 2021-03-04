using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.WebApi.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<PaciakUser>> GetUsers();
    }
}