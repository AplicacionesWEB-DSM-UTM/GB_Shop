using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GB_Shop.Domain.Entities;

#nullable disable

namespace GB_Shop.Infrastruture.Data
{
    public partial class GB_ShopContext : DbContext
    {
        public GB_ShopContext()
        {
        }

        public GB_ShopContext(DbContextOptions<GB_ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-AP83LF2M;Initial Catalog=GB_Shop;User ID=GB_Shop;Password=123456789;Persist Security Info=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("db_accessadmin")
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEven);

                entity.ToTable("Eventos", "dbo");

                entity.Property(e => e.IdEven)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Even");

                entity.Property(e => e.CantPersonEven).HasColumnName("Cant_person_even");

                entity.Property(e => e.CaracteristicasEven)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Caracteristicas_even");

                entity.Property(e => e.FechaEven)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_even");

                entity.Property(e => e.HoraEven).HasColumnName("Hora_even");

                entity.Property(e => e.NameEven)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_even");

                entity.Property(e => e.UbicEven)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Ubic_even");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.ToTable("Fotos", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Fotos)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Foto)
                    .HasForeignKey<Foto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fotos_Reporte");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.ToTable("Reporte", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Colonia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DecripLugar)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Decrip_lugar");

                entity.Property(e => e.FechaDenuncia)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Denuncia");

                entity.Property(e => e.GeoUbi)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Geo_ubi");

                entity.Property(e => e.MotivoDenuncia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Motivo_Denuncia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
