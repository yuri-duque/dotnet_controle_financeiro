using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    class ExpenseRepository : Repository<Income>
    {
        public IncomeRepository(BaseContext ctx) : base(ctx) { }
    }
}
