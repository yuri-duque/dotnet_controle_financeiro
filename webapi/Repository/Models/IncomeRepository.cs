using Domain.Models;
using Repository.Context;

namespace Repository.Models
{
    public class IncomeRepository : Repository<Income>
    {
        public IncomeRepository(BaseContext ctx) : base(ctx) { }
    }
}
