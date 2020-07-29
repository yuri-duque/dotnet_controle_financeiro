using AutoMapper;
using Repository.ModelsRepository;

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
    }
}
