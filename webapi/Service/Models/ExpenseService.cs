using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.Models;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Models
{
    public class ExpenseService
    {
        private readonly ExpenseRepository _expenseRepository;
        private readonly WalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public ExpenseService(ExpenseRepository expenseRepository, WalletRepository walletRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<ExpenseListDTO>> GetAll(long idUser, long idWallet)
        {
            var expenses = _expenseRepository.GetAllExpenses(idUser, idWallet).ToList();

            var expensesDTO = _mapper.Map<IList<ExpenseListDTO>>(expenses);

            return ServiceResponse<IList<ExpenseListDTO>>.SetSuccess(expensesDTO);
        }

        public ServiceResponse<Expense> Save(long idUser, ExpenseFormDTO expenseDTO)
        {
            var walletExist = _walletRepository.GetById(idUser, expenseDTO.IdWallet);

            if (walletExist == null)
                return ServiceResponse<Expense>.SetError("Carteira não encontrada!");

            var expense = _mapper.Map<Expense>(expenseDTO);
            expense.DateRegister = DateTime.Now;

            _expenseRepository.Save(expense);

            return ServiceResponse<Expense>.SetSuccess(expense);
        }
    }
}
