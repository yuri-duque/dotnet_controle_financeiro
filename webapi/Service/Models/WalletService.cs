using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.Models;
using Service.Utils;
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

        public ServiceResponse<IList<User>> GetAll()
        {
            var users = _userRepository.GetAll().ToList();

            return ServiceResponse<IList<User>>.SetSuccess(users);
        }

        public ServiceResponse<User> GetById(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
                return ServiceResponse<User>.SetError("Usuário não encontrado");

            return ServiceResponse<User>.SetSuccess(user);
        }

        public ServiceResponse<Wallet> Save(WalletFormDTO walletDTO, long idUser)
        {
            var wallet = _mapper.Map<Wallet>(walletDTO);

            wallet.IdUser = idUser;

            _walletRepository.Save(wallet);

            return ServiceResponse<Wallet>.SetSuccess(null);
        }

        //public void Update(User usuario)
        //{
        //    _userRepository.Save(usuario);
        //}

        //public void Delete(long Id)
        //{
        //    _userRepository.Delete(x => x.Id == Id);
        //}
    }
}
