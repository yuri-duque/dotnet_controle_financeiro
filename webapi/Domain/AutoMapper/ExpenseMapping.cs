using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class ExpenseMapping : Profile
    {
        public ExpenseMapping()
        {
            CreateMap<Expense, ExpenseListDTO>().ReverseMap();
        }
    }
}
