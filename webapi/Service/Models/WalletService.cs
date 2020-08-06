using AutoMapper;
using Domain.DTO;
using Repository.Models;
using System;

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

        public object Save(WalletFormDTO walletDTO, long idUser)
        {
            throw new NotImplementedException();
        }
    }
}
