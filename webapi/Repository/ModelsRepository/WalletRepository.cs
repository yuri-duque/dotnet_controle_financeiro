using Domain.Models;
using Repository.Context;

namespace Repository.ModelsRepository
{
    public class WalletRepository : Repository<Wallet>
    {
        public WalletRepository(BaseContext ctx) : base(ctx) { }
    }
}
