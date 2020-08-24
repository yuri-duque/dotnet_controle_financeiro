using Domain.Models;
using Repository.Context;

namespace Repository.Models
{
    public class ExpenseRepository : Repository<Expense>
    {
        public ExpenseRepository(BaseContext ctx) : base(ctx) { }
    }
}
