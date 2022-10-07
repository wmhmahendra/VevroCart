using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CART_DataAcces.Models;

namespace CART_DataAcces.Data
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartAddress> CartAddresses { get; set; } = null!;
        public virtual DbSet<CartCreditCard> CartCreditCards { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<CartOrder> CartOrders { get; set; } = null!;
        public virtual DbSet<CartOrderDetail> CartOrderDetails { get; set; } = null!;
        public virtual DbSet<CartUser> CartUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=HASITHA-LAPTOP;database=VevroCartDB;persist security info=True;user id=sa;password=sa@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartAddress>(entity =>
            {
                entity.ToTable("Cart_Address");

                entity.Property(e => e.Email).HasColumnName("email");
            });

            modelBuilder.Entity<CartCreditCard>(entity =>
            {
                entity.ToTable("Cart_CreditCard");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Items");

                entity.Property(e => e.DiscountedPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CartOrder>(entity =>
            {
                entity.ToTable("Cart_Orders");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CartOrders)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_Orders_CreditCard_CardId");
            });

            modelBuilder.Entity<CartOrderDetail>(entity =>
            {
                entity.ToTable("Cart_OrderDetails");

                entity.Property(e => e.ItemUnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CartOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders_OrderId");
            });

            modelBuilder.Entity<CartUser>(entity =>
            {
                entity.ToTable("Cart_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
