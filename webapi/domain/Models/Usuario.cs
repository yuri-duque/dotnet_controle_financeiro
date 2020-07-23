using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Usuario>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            map.HasIndex(x => x.Username).IsUnique();
        }
    }
}
