using Domain.Models;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.Models
{
    public class ExpenseRepository : Repository<Expense>
    {
        public ExpenseRepository(BaseContext ctx) : base(ctx) { }

        public IQueryable<Expense> GetAllExpenses(long idUser, long idWallet)
        {
            return GetAll().Where(x => x.IdWallet == idWallet && x.wallet.IdUser == idUser);
        }

        public Expense GetById(long idUser, long idExpense)
        {
            return GetAll().FirstOrDefault(x => x.Id == idExpense && x.wallet.IdUser == idUser);
        }
    }
}
