using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GB_Shop.Domain.Entities;

#nullable disable

namespace GB_Shop.Infraestructure.Data
{
    public partial class GB_shopContext : DbContext
    {
        public GB_shopContext()
        {
        }

        public GB_shopContext(DbContextOptions<GB_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsideracionesEsp> ConsideracionesEsps { get; set; }
        public virtual DbSet<Denuncia> Denuncias { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<MotivosDenuncium> MotivosDenuncia { get; set; }
        public virtual DbSet<Patrocinadore> Patrocinadores { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=GBshop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("db_accessadmin")
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ConsideracionesEsp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Consideraciones_esp", "dbo");

                entity.Property(e => e.ConsideracionesEsp1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Consideraciones_esp");

                entity.Property(e => e.IdConsideraciones)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_Consideraciones");
            });

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PK__Denuncia__DE8C5D3E376A5259");

                entity.ToTable("Denuncias", "dbo");

                entity.Property(e => e.IdReporte).HasColumnName("ID_Reporte");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

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

                entity.Property(e => e.IdFoto).HasColumnName("ID_Foto");

                entity.Property(e => e.IdMotivo).HasColumnName("ID_motivo");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEven)
                    .HasName("PK__Eventos__6069AFA373B088EA");

                entity.ToTable("Eventos", "dbo");

                entity.Property(e => e.IdEven).HasColumnName("ID_Even");

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
                    .HasName("PK__Foto__195DD875D645FE24");

                entity.ToTable("Foto", "dbo");

                entity.Property(e => e.IdFoto)
                    .ValueGeneratedOnAdd()
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

            modelBuilder.Entity<MotivosDenuncium>(entity =>
            {
                entity.HasKey(e => e.IdMotivo)
                    .HasName("PK__MotivosD__9535A4AD52DC994D");

                entity.ToTable("MotivosDenuncia", "dbo");

                entity.Property(e => e.IdMotivo).HasColumnName("ID_motivo");

                entity.Property(e => e.Motivos)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patrocinadore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Patrocinadores", "dbo");

                entity.Property(e => e.IdPatrocinador)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_Patrocinador");

                entity.Property(e => e.Patrocinador)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPatrocinadorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPatrocinador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Eventos");
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("POI", "dbo");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Confirmar)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.GeoUbiDen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GeoUbi_Den");

                entity.Property(e => e.IdMotivo).HasColumnName("ID_motivo");

                entity.Property(e => e.IdPoi)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_poi");

                entity.Property(e => e.Rechazar)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPoiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPoi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MotivosDenuncia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
