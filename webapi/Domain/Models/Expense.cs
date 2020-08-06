using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Expense
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public long IdWallet { get; set; }
        public Wallet wallet { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Expense>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            map.HasOne(x => x.wallet).WithMany(x => x.Expenses).HasForeignKey(x => x.IdWallet).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
