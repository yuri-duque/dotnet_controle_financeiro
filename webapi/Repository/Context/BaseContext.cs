using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Expense.Map(modelBuilder);
            Income.Map(modelBuilder);
            User.Map(modelBuilder);
            Wallet.Map(modelBuilder);
        }

        public DbSet<Expense> expenses { get; set; }
        public DbSet<Income> incomes { get; set; }
        public DbSet<User> usuarios { get; set; }
        public DbSet<Wallet> wallets { get; set; }
    }
}
