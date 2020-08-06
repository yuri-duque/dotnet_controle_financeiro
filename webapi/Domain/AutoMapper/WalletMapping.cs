using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class WalletMapping : Profile
    {
        public WalletMapping()
        {
            CreateMap<Wallet, WalletFormDTO>().ReverseMap();
        }
    }
}
