using Domain.Models;
using Repository.Context;
using System.Linq;

namespace Repository.Models
{
    public class IncomeRepository : Repository<Income>
    {
        public IncomeRepository(BaseContext ctx) : base(ctx) { }

        public IQueryable<Income> GetAllIncomes(long idUser, long idWallet)
        {
            return GetAll().Where(x => x.IdWallet == idWallet && x.wallet.IdUser == idUser);
        }
    }
}
