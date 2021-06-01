using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConsoleApp1.Entities;

#nullable disable

namespace ConsoleApp1.Context
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

        public virtual DbSet<MaterialEstudio> MaterialEstudio { get; set; }

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

            modelBuilder.Entity<MaterialEstudio>(entity =>
            {
                entity.HasKey(e => e.IdMaterial);

                entity.HasIndex(e => e.IdIdioma, "IX_MaterialEstudio_idIdioma");

                entity.HasIndex(e => e.IdMateria, "IX_MaterialEstudio_idMateria");

                entity.HasIndex(e => e.IdUniversidad, "IX_MaterialEstudio_idUniversidad");

                entity.HasIndex(e => e.IdUsuario, "IX_MaterialEstudio_idUsuario");

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
                    .HasMaxLength(180)
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
                    .HasMaxLength(1250)
                    .IsUnicode(false)
                    .HasColumnName("prologo");

                entity.Property(e => e.TipoArchivo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("tipoArchivo");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
