using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class User_Wallet
    {
        public long IdUser { get; set; }
        public User User { get; set; }

        public long IdWallet { get; set; }
        public Wallet Wallet { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<User_Wallet>();
            map.HasKey(x => new { x.IdUser, x.IdWallet });

            map.HasOne(xy => xy.User).WithMany(x => x.Wallets).HasForeignKey(xy => xy.IdUser);
            map.HasOne(xy => xy.Wallet).WithMany(y => y.Users).HasForeignKey(xy => xy.IdWallet);
        }
    }
}
