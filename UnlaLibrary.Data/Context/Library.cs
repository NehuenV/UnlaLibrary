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
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Universidad> Universidad { get; set; }
        public virtual DbSet<UniversidadCarrera> UniversidadCarrera { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioMateria> UsuarioMateria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1LSVL80;Database=UnlaLibrary;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__Carrera__7B19E7913E1F87D6");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Carrera1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("carrera");
            });

            modelBuilder.Entity<CarreraMateria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Carrera_Materia");

                entity.HasIndex(e => e.IdCarrera, "IX_Carrera_Materia_idCarrera");

                entity.HasIndex(e => e.IdMateria, "IX_Carrera_Materia_idMateria");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrera_Materia");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materia_Carrera");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PK__Idioma__A96571FC398F9DC2");

                entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");

                entity.Property(e => e.Idioma1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("idioma");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__Materia__4B740AB3F639A85A");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.Materia1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("materia");
            });

            modelBuilder.Entity<MaterialEstudio>(entity =>
            {
                entity.HasKey(e => e.IdMateriaEstudio)
                    .HasName("PK__Material__518559FD9A647BD5");

                entity.Property(e => e.IdMateriaEstudio).HasColumnName("idMateriaEstudio");

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

                entity.Property(e => e.Idioma).HasColumnName("idioma");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Miniatura)
                    .IsRequired()
                    .HasColumnName("miniatura");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.HasOne(d => d.IdiomaNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.Idioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Idioma_MateriaEstudio");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.Materia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materia_MateriaEstudio");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.MaterialEstudio)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_MateriaEstudio");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF287FB897");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NombreTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipoUsuario");
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.IdUniversidad)
                    .HasName("PK__Universi__AFB9D2244D38274E");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.NombreUniversidad)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreUniversidad");
            });

            modelBuilder.Entity<UniversidadCarrera>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Universidad_Carrera");

                entity.HasIndex(e => e.IdCarrera, "IX_Universidad_Carrera_idCarrera");

                entity.HasIndex(e => e.IdUniversidad, "IX_Universidad_Carrera_idUniversidad");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrera_Universidad");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUniversidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Universidad_Carrera");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6B1240B31");

                entity.HasIndex(e => e.TipoUsuario, "IX_Usuario_tipoUsuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                
                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoUsuario).HasColumnName("tipoUsuario");

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            modelBuilder.Entity<UsuarioMateria>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.IdMateria, "IX_UsuarioMateria_idMateria");

                entity.HasIndex(e => e.IdUsuario, "IX_UsuarioMateria_idUsuario");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Materia");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materia_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
