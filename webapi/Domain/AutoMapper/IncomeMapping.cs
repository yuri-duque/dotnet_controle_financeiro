using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class IncomeMapping : Profile
    {
        public IncomeMapping()
        {
            CreateMap<Income, IncomeListDTO>().ReverseMap();
            CreateMap<Income, IncomeFormDTO>().ReverseMap();
        }
    }
}
