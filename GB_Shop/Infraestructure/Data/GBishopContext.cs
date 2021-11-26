using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GB_Shop.Domain.Entities;

#nullable disable

namespace GB_Shop.Infraestructure.Data
{
    public partial class GBishopContext : DbContext
    {
        public GBishopContext()
        {
        }

        public GBishopContext(DbContextOptions<GBishopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsideracionesEsp> ConsideracionesEsps { get; set; }
        public virtual DbSet<Denuncia> Denuncias { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Patrocinadore> Patrocinadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-AP83LF2M;Initial Catalog=GBishop;User ID=GB_Shop;Password=123456789;Persist Security Info=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("db_accessadmin")
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ConsideracionesEsp>(entity =>
            {
                entity.HasKey(e => e.IdConsideraciones)
                    .HasName("PK__Consider__5772F25AE9DB8B82");

                entity.ToTable("Consideraciones_esp", "dbo");

                entity.Property(e => e.IdConsideraciones)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Consideraciones");

                entity.Property(e => e.ConsideracionesEsp1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Consideraciones_esp");

                entity.HasOne(d => d.IdConsideracionesNavigation)
                    .WithOne(p => p.ConsideracionesEsp)
                    .HasForeignKey<ConsideracionesEsp>(d => d.IdConsideraciones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consideraciones_esp_Evento");
            });

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PK__Denuncia");

                entity.ToTable("Denuncias", "dbo");

                entity.Property(e => e.IdReporte)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Reporte");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DFoto).HasColumnName("D_Foto");

                entity.Property(e => e.DescLugar)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Desc_lugar");

                entity.Property(e => e.FechaDen)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Den");

                entity.Property(e => e.GeoUbiDen)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GeoUbi_Den");

                entity.Property(e => e.MotivoDen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Motivo_Den");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEven)
                    .HasName("PK__Evento__6069AFA32FC8F864");

                entity.ToTable("Evento", "dbo");

                entity.Property(e => e.IdEven)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Even");

                entity.Property(e => e.CantPersonas).HasColumnName("Cant_Personas");

                entity.Property(e => e.CaractEven)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Caract_Even");

                entity.Property(e => e.FechaEven)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Even");

                entity.Property(e => e.GeoUbiEve)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GeoUbi_Eve");

                entity.Property(e => e.HoraEven).HasColumnName("Hora_Even");

                entity.Property(e => e.IdConsideraciones).HasColumnName("ID_Consideraciones");

                entity.Property(e => e.IdPatrocinador).HasColumnName("ID_Patrocinador");

                entity.Property(e => e.UbicEven)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Ubic_Even");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.IdFoto)
                    .HasName("PK__Foto__195DD875DE19F064");

                entity.ToTable("Foto", "dbo");

                entity.Property(e => e.IdFoto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Foto");

                entity.Property(e => e.Foto1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Foto");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithOne(p => p.Foto)
                    .HasForeignKey<Foto>(d => d.IdFoto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Denuncias");
            });

            modelBuilder.Entity<Patrocinadore>(entity =>
            {
                entity.HasKey(e => e.IdPatrocinadores)
                    .HasName("PK__Patrocin__4680CDF75C85599E");

                entity.ToTable("Patrocinadores", "dbo");

                entity.Property(e => e.IdPatrocinadores)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Patrocinadores");

                entity.Property(e => e.Patrocinador)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPatrocinadoresNavigation)
                    .WithOne(p => p.Patrocinadore)
                    .HasForeignKey<Patrocinadore>(d => d.IdPatrocinadores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Evento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
