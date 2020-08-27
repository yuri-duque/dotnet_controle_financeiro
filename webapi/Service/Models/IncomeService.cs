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
    public class IncomeService
    {
        private readonly IncomeRepository _incomeRepository;
        private readonly WalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public IncomeService(IncomeRepository incomeRepository, WalletRepository walletRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<IncomeListDTO>> GetAll(long idUsuario, long idWallet)
        {
            var incomes = _incomeRepository.GetAllIncomes(idUsuario, idWallet).ToList();

            var incomesDTO = _mapper.Map<IList<IncomeListDTO>>(incomes);

            return ServiceResponse<IList<IncomeListDTO>>.SetSuccess(incomesDTO);
        }

        public ServiceResponse<IList<IncomeFormDTO>> GetById(long idUser, long idIncome)
        {
            var income = _incomeRepository.GetById(idUser, idIncome);

            var incomeDTO = _mapper.Map<IList<IncomeFormDTO>>(income);

            return ServiceResponse<IList<IncomeFormDTO>>.SetSuccess(incomeDTO);
        }

        
    }
}
