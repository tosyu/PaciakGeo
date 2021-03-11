using AutoMapper;
using PaciakGeo.Common.Models;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Configuration.AutomapperProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}