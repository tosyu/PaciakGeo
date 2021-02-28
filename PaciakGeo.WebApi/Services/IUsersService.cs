using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<PaciakUser>> GetUsers();
    }
}