using AutoMapper;
using Domain.DTO;
using Repository.Models;
using Service.Utils;
using System.Collections.Generic;
using System.Linq;

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

        public ServiceResponse<IList<ExpenseListDTO>> GetAll(long idUser, long idWallet)
        {
            var incomes = _expenseRepository.GetAllExpenses(idUser, idWallet).ToList();

            var incomesDTO = _mapper.Map<IList<ExpenseListDTO>>(incomes);

            return ServiceResponse<IList<ExpenseListDTO>>.SetSuccess(incomesDTO);
        }
    }
}
