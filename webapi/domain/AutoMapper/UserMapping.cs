using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<Usuario, UserLoginDTO>().ReverseMap();
            CreateMap<Usuario, UserRegisterDTO>().ReverseMap();
            CreateMap<Usuario, UserDTO>().ReverseMap();
        }
    }
}
