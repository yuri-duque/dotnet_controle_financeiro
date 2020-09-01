using AutoMapper;

namespace Domain.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            new ExpenseMapping();
            new IncomeMapping();
            new UserMapping();
            new WalletMapping();
        }
    }
}
