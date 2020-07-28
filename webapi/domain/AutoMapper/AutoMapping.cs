using AutoMapper;
using domain.AutoMapper;

namespace Domain.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            new UserMapping();
        }
    }
}
