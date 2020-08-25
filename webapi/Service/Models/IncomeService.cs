using AutoMapper;
using Domain.DTO;
using Repository.Models;
using Service.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Service.Models
{
    public class IncomeService
    {
        private readonly IncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<IncomeListDTO>> GetAll(long idUsuario, long idWallet)
        {
            var incomes = _incomeRepository.GetAllIncomes(idUsuario, idWallet).ToList();

            var incomesDTO = _mapper.Map<IList<IncomeListDTO>>(incomes);

            return ServiceResponse<IList<IncomeListDTO>>.SetSuccess(incomesDTO);
        }
    }
}
