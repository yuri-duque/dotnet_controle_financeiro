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

        public IList<User_Wallet> Users { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Wallet>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
