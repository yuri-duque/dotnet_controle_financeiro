using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public decimal Saldo { get; set; }

        public IList<Usuario_Conta> Usuarios { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Conta>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
