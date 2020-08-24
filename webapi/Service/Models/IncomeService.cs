using AutoMapper;

namespace Service.Models
{
    public class IncomeService
    {
        private readonly IncomeService _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IncomeService incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
    }
}
