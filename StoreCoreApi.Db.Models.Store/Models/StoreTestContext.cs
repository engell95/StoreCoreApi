using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreCoreApi.Db.Models.Store.Models
{
    public partial class StoreTestContext : DbContext
    {
        public StoreTestContext()
        {
        }

        public StoreTestContext(DbContextOptions<StoreTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreProductMapping> StoreProductMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DELLPC;Initial Catalog=StoreTest;User Id=Dell/lopez;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreProductMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__StorePro__8B5781BDA0F80345");

                entity.ToTable("StoreProductMapping");

                entity.Property(e => e.MappingId).HasColumnName("MappingID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoreProd__Produ__3C69FB99");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreProductMappings)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoreProd__Store__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
