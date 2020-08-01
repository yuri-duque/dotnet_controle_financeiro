﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20200801024757_update-1")]
    partial class update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EmailVerifyCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Domain.Models.User_Wallet", b =>
                {
                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<long>("IdWallet")
                        .HasColumnType("bigint");

                    b.HasKey("IdUser", "IdWallet");

                    b.HasIndex("IdWallet");

                    b.ToTable("users_wallets");
                });

            modelBuilder.Entity("Domain.Models.Wallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(16,2)");

                    b.HasKey("Id");

                    b.ToTable("wallets");
                });

            modelBuilder.Entity("Domain.Models.User_Wallet", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Wallet", "Wallet")
                        .WithMany("Users")
                        .HasForeignKey("IdWallet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
