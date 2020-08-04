﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Income
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
            var map = modelBuilder.Entity<Income>();
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            map.HasOne(x => x.wallet).WithMany(x => x.incomes).HasForeignKey(x => x.IdWallet).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
