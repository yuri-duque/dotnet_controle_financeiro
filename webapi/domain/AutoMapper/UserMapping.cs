using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
