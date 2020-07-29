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

            Usuario.Map(modelBuilder);
            Usuario.Map(modelBuilder);
        }

        public DbSet<Conta> contas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Usuario_Conta> usuarios_contas { get; set; }
    }
}
