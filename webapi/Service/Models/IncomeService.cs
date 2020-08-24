using AutoMapper;

namespace Service.Models
{
    public class IncomeRepository
    {
        private readonly IncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeRepository(IncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
    }
}
