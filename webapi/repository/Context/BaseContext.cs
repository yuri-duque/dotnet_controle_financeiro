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

            Wallet.Map(modelBuilder);
            User.Map(modelBuilder);
            User_Wallet.Map(modelBuilder);
        }

        public DbSet<Wallet> wallets { get; set; }
        public DbSet<User> usuarios { get; set; }
        public DbSet<User_Wallet> users_wallets { get; set; }
    }
}
