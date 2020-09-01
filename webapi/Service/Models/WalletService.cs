using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.Models;
using Service.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Service.Models
{
    public class WalletService
    {
        private readonly WalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public WalletService(WalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<WalletListDTO>> GetAll(long idUser)
        {
            var wallets = _walletRepository.GetAllByUser(idUser).ToList();

            wallets = wallets.Select(x =>
            {
                if (x.Incomes.Any())
                {
                    decimal valor = x.Incomes.Sum(x => x.Value);
                    x.Balance += valor;
                }

                if (x.Expenses.Any())
                {
                    decimal valor = x.Expenses.Sum(x => x.Value);
                    x.Balance -= valor;
                }
                return x;
            }).ToList();

            var walletsDTO = _mapper.Map<IList<WalletListDTO>>(wallets);

            return ServiceResponse<IList<WalletListDTO>>.SetSuccess(walletsDTO);
        }

        public ServiceResponse<Wallet> GetById(long idUser, long id)
        {
            var wallet = _walletRepository.GetById(idUser, id);

            if (wallet == null)
                return ServiceResponse<Wallet>.SetError("Carteira não encontrado");

            return ServiceResponse<Wallet>.SetSuccess(wallet);
        }

        public ServiceResponse<Wallet> Save(WalletFormDTO walletDTO, long idUser)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);

            wallet.IdUser = idUser;

            _walletRepository.Save(wallet);

            return ServiceResponse<Wallet>.SetSuccess(wallet);
        }
    }
}
