using AutoMapper;
using PageCss.Core.Entities;
using PageCss.Core.ViewModelsIn;
using PageCss.Core.ViewModelsOut;

namespace PageCss.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UsersViewModelIn>().ReverseMap();
            CreateMap<User, UsersViewModelOut>().ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
        }
    }
}
