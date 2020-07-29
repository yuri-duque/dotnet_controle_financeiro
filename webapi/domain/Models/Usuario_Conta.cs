using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class Usuario_Conta
    {
        public long IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public long IdConta { get; set; }
        public Conta Conta { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Usuario_Conta>();
            map.HasKey(x => new { x.IdUsuario, x.IdConta });

            map.HasOne(xy => xy.Usuario).WithMany(x => x.Contas).HasForeignKey(xy => xy.IdUsuario);
            map.HasOne(xy => xy.Conta).WithMany(y => y.Usuarios).HasForeignKey(xy => xy.IdConta);
        }
    }
}
