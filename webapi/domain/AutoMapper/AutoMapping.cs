using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioLoginDTO>().ReverseMap();
        }
    }
}
