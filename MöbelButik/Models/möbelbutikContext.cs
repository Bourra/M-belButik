using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MöbelButik.Models
{
    public partial class möbelbutikContext : DbContext
    {
        public möbelbutikContext()
        {
        }

        public möbelbutikContext(DbContextOptions<möbelbutikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Färg> Färgs { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Produkt> Produkts { get; set; }
        public virtual DbSet<Tillverkare> Tillverkares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=möbelbutik;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Färg>(entity =>
            {
                entity.ToTable("Färg");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.ToTable("Produkt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProduktNamn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FärgNavigation)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Färg)
                    .HasConstraintName("FK_Produkt.Färg");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Produkt.KategoriId");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("FK_Produkt.Material");

                entity.HasOne(d => d.Tillverkare)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.TillverkareId)
                    .HasConstraintName("FK_Produkt.TillverkareId");
            });

            modelBuilder.Entity<Tillverkare>(entity =>
            {
                entity.ToTable("Tillverkare");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Land)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Namn)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
