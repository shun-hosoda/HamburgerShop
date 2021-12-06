using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HamburgerShop.Infrastructure.Entity
{
    public partial class HamburgerShopContext : DbContext
    {
        public HamburgerShopContext()
        {
        }

        public HamburgerShopContext(DbContextOptions<HamburgerShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=8889;Database=HamburgerShop;User Id=hosoda;Password=P@ssw0rd;SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ImageLink)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemPrice).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PRIMARY");

                entity.Property(e => e.OrderDetailId).HasColumnType("int(11)");

                entity.Property(e => e.Discount).HasColumnType("int(11)");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.OrderTypeId).HasColumnType("int(11)");

                entity.Property(e => e.PaymentAmount).HasColumnType("int(11)");

                entity.Property(e => e.PaymentRefund).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.Tax).HasColumnType("int(11)");

                entity.Property(e => e.Total).HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.Property(e => e.OrderTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.OrderTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaxId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.FinalTotal).HasColumnType("int(11)");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaymentTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Tax).HasColumnType("int(11)");
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId)
                    .HasName("PRIMARY");

                entity.Property(e => e.PaymentTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.Property(e => e.TaxId).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
