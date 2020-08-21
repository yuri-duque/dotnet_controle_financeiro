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
            var walletsDTO = _walletRepository.GetAllByUser(idUser).ToList();

            var wallets = _mapper.Map<IList<WalletListDTO>>(walletsDTO);

            return ServiceResponse<IList<WalletListDTO>>.SetSuccess(wallets);
        }

        public ServiceResponse<Wallet> GetById(long id)
        {
            var wallet = _walletRepository.Find(id);

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
