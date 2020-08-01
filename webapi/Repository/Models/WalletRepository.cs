using Domain.Models;
using Repository.Context;

namespace Repository.Models
{
    public class WalletRepository : Repository<Wallet>
    {
        public WalletRepository(BaseContext ctx) : base(ctx) { }
    }
}
