using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Wallet
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Balance { get; set; }

        [Required]
        public string Name { get; set; }

        //Relationship
        public long IdUser { get; set; }
        public User User { get; set; }

        public IList<Income> Incomes { get; set; }
        public IList<Expense> Expenses { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Wallet>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            map.HasOne(x => x.User).WithMany(x => x.Wallets).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
