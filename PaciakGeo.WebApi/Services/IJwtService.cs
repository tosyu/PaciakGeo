using PaciakGeo.Common.Models;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Services
{
    public interface IJwtService
    {
        string CreateJwtToken(PaciakUser paciakUser);
    }
}