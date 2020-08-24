using AutoMapper;
using Repository.Models;

namespace Service.Models
{
    public class ExpenseService
    {
        private readonly ExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseService(ExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }
    }
}
