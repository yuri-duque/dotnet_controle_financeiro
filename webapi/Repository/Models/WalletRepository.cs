using Domain.Models;
using Repository.Context;
using System.Linq;

namespace Repository.Models
{
    public class WalletRepository : Repository<Wallet>
    {
        public WalletRepository(BaseContext ctx) : base(ctx) { }

        public IQueryable<Wallet> GetAllByUser(long idUser)
        {
            return GetAll().Where(x => x.IdUser == idUser);
        }

        public Wallet GetById(long idUser, long id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id && x.IdUser == idUser);
        }
    }
}
