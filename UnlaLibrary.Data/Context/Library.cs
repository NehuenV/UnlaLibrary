using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UnlaLibrary.Data.Entities;

#nullable disable

namespace UnlaLibrary.Data.Context
{
    public partial class Library : DbContext
    {
        public Library()
        {
        }

        public Library(DbContextOptions<Library> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<CarreraMateria> CarreraMateria { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<MaterialEstudio> MaterialEstudio { get; set; }
        public virtual DbSet<Reseña> Reseña { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Universidad> Universidad { get; set; }
        public virtual DbSet<UniversidadCarrera> UniversidadCarrera { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioCarreraUniversidad> UsuarioCarreraUniversidad { get; set; }
        public virtual DbSet<UsuarioMateria> UsuarioMateria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1LSVL80;Database=UnlaLibrary2.0;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Carrera1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("carrera");
            });

            modelBuilder.Entity<CarreraMateria>(entity =>
            {
                entity.HasKey(e => new { e.IdCarrera, e.IdMateria });

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.CarreraMateria)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarreraMateria_Carrera");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.CarreraMateria)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarreraMateria_Materia");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma);

                entity.Property(e => e.IdIdioma)
                    .ValueGeneratedNever()
                    .HasColumnName("idIdioma");

                entity.Property(e => e.Idioma1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("idioma");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.Materia1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("Materia");
            });

            modelBuilder.Entity<MaterialEstudio>(entity =>
            {
                entity.HasKey(e => e.IdMaterial);

                entity.Property(e => e.Archivo)
                    .IsRequired()
                    .HasColumnName("archivo");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("autor");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Miniatura)
                    .IsRequired()
                    .HasColumnName("miniatura");

                entity.Property(e => e.Prologo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("prologo");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdIdiomaNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.IdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialEstudio_Idioma");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialEstudio_Materia");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.IdUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialEstudio_Universidad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialEstudio_Usuario");
            });

            modelBuilder.Entity<Reseña>(entity =>
            {
                entity.HasKey(e => e.IdReseña);

                entity.Property(e => e.IdReseña).HasColumnName("idReseña");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Reseña)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reseña_MaterialEstudio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reseña)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reseña_Usuario");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NombreTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipoUsuario");
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.IdUniversidad);

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.NombreUniversidad)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreUniversidad");
            });

            modelBuilder.Entity<UniversidadCarrera>(entity =>
            {
                entity.HasKey(e => new { e.IdUniversidad, e.IdCarrera });

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.UniversidadCarrera)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversidadCarrera_Carrera");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.UniversidadCarrera)
                    .HasForeignKey(d => d.IdUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UniversidadCarrera_Universidad");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            modelBuilder.Entity<UsuarioCarreraUniversidad>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdCarrera, e.IdUniversidad });

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.UsuarioCarreraUniversidad)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCarreraUniversidad_Carrera");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.UsuarioCarreraUniversidad)
                    .HasForeignKey(d => d.IdUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCarreraUniversidad_Universidad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioCarreraUniversidad)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCarreraUniversidad_Usuario");
            });

            modelBuilder.Entity<UsuarioMateria>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdMateria });

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.UsuarioMateria)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioMateria_Materia");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioMateria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioMateria_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
