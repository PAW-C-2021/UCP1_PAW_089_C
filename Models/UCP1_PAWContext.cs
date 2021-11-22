using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_089_C.Models
{
    public partial class UCP1_PAWContext : DbContext
    {
        public UCP1_PAWContext()
        {
        }

        public UCP1_PAWContext(DbContextOptions<UCP1_PAWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Penjual> Penjuals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("login");

                entity.Property(e => e.IdLogin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pembeli");

                entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_pembeli");

                entity.Property(e => e.NoHpPembeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("noHP_pembeli");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.Pembelis)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_pembeli_transaksi");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual)
                    .HasName("PK_produk");

                entity.ToTable("penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("id_penjual");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.EmailPenjual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email_penjual");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");

                entity.Property(e => e.NamaPenjual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_penjual");

                entity.Property(e => e.NoHpPenjual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("noHP_penjual");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_penjual_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("product");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("id_produk");

                entity.Property(e => e.Harga)
                    .HasMaxLength(10)
                    .HasColumnName("harga")
                    .IsFixedLength(true);

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_produk");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("id_transaksi");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_transaksi_product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
