﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnlaLibrary.Data.Context;

namespace UnlaLibrary.Data.Migrations
{
    [DbContext(typeof(Library))]
    partial class LibraryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Carrera", b =>
                {
                    b.Property<int>("IdCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCarrera")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carrera1")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("carrera");

                    b.HasKey("IdCarrera")
                        .HasName("PK__Carrera__7B19E7913E1F87D6");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.CarreraMateria", b =>
                {
                    b.Property<int>("IdCarrera")
                        .HasColumnType("int")
                        .HasColumnName("idCarrera");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int")
                        .HasColumnName("idMateria");

                    b.HasIndex(new[] { "IdCarrera" }, "IX_Carrera_Materia_idCarrera");

                    b.HasIndex(new[] { "IdMateria" }, "IX_Carrera_Materia_idMateria");

                    b.ToTable("Carrera_Materia");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Idioma", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idIdioma")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Idioma1")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("idioma");

                    b.HasKey("IdIdioma")
                        .HasName("PK__Idioma__A96571FC398F9DC2");

                    b.ToTable("Idioma");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Materia", b =>
                {
                    b.Property<int>("IdMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMateria")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Materia1")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("materia");

                    b.HasKey("IdMateria")
                        .HasName("PK__Materia__4B740AB3F639A85A");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.MaterialEstudio", b =>
                {
                    b.Property<int>("IdMateriaEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMateriaEstudio")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Archivo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("archivo");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("autor");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Idioma")
                        .HasColumnType("int")
                        .HasColumnName("idioma");

                    b.Property<int>("Materia")
                        .HasColumnType("int")
                        .HasColumnName("materia");

                    b.Property<byte[]>("Miniatura")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("miniatura");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("titulo");

                    b.Property<int>("Usuario")
                        .HasColumnType("int")
                        .HasColumnName("usuario");

                    b.HasKey("IdMateriaEstudio")
                        .HasName("PK__Material__518559FD9A647BD5");

                    b.HasIndex("Idioma");

                    b.HasIndex("Materia");

                    b.HasIndex("Usuario");

                    b.ToTable("MaterialEstudio");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoUsuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoUsuario")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombreTipoUsuario");

                    b.HasKey("IdTipoUsuario")
                        .HasName("PK__TipoUsua__03006BFF287FB897");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Universidad", b =>
                {
                    b.Property<int>("IdUniversidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUniversidad")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreUniversidad")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombreUniversidad");

                    b.HasKey("IdUniversidad")
                        .HasName("PK__Universi__AFB9D2244D38274E");

                    b.ToTable("Universidad");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.UniversidadCarrera", b =>
                {
                    b.Property<int>("IdCarrera")
                        .HasColumnType("int")
                        .HasColumnName("idCarrera");

                    b.Property<int>("IdUniversidad")
                        .HasColumnType("int")
                        .HasColumnName("idUniversidad");

                    b.HasIndex(new[] { "IdCarrera" }, "IX_Universidad_Carrera_idCarrera");

                    b.HasIndex(new[] { "IdUniversidad" }, "IX_Universidad_Carrera_idUniversidad");

                    b.ToTable("Universidad_Carrera");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("clave");

                    b.Property<long>("Dni")
                        .HasColumnType("bigint")
                        .HasColumnName("dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int")
                        .HasColumnName("tipoUsuario");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__645723A6B1240B31");

                    b.HasIndex(new[] { "TipoUsuario" }, "IX_Usuario_tipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.UsuarioMateria", b =>
                {
                    b.Property<int>("IdMateria")
                        .HasColumnType("int")
                        .HasColumnName("idMateria");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.HasIndex(new[] { "IdMateria" }, "IX_UsuarioMateria_idMateria");

                    b.HasIndex(new[] { "IdUsuario" }, "IX_UsuarioMateria_idUsuario");

                    b.ToTable("UsuarioMateria");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.CarreraMateria", b =>
                {
                    b.HasOne("UnlaLibrary.Data.Entities.Carrera", "IdCarreraNavigation")
                        .WithMany()
                        .HasForeignKey("IdCarrera")
                        .HasConstraintName("FK_Carrera_Materia")
                        .IsRequired();

                    b.HasOne("UnlaLibrary.Data.Entities.Materia", "IdMateriaNavigation")
                        .WithMany()
                        .HasForeignKey("IdMateria")
                        .HasConstraintName("FK_Materia_Carrera")
                        .IsRequired();

                    b.Navigation("IdCarreraNavigation");

                    b.Navigation("IdMateriaNavigation");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.MaterialEstudio", b =>
                {
                    b.HasOne("UnlaLibrary.Data.Entities.Idioma", "IdiomaNavigation")
                        .WithMany("MaterialEstudio")
                        .HasForeignKey("Idioma")
                        .HasConstraintName("FK_Idioma_MateriaEstudio")
                        .IsRequired();

                    b.HasOne("UnlaLibrary.Data.Entities.Materia", "MateriaNavigation")
                        .WithMany("MaterialEstudio")
                        .HasForeignKey("Materia")
                        .HasConstraintName("FK_Materia_MateriaEstudio")
                        .IsRequired();

                    b.HasOne("UnlaLibrary.Data.Entities.Usuario", "UsuarioNavigation")
                        .WithMany("MaterialEstudio")
                        .HasForeignKey("Usuario")
                        .HasConstraintName("FK_Usuario_MateriaEstudio")
                        .IsRequired();

                    b.Navigation("IdiomaNavigation");

                    b.Navigation("MateriaNavigation");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.UniversidadCarrera", b =>
                {
                    b.HasOne("UnlaLibrary.Data.Entities.Carrera", "IdCarreraNavigation")
                        .WithMany()
                        .HasForeignKey("IdCarrera")
                        .HasConstraintName("FK_Carrera_Universidad")
                        .IsRequired();

                    b.HasOne("UnlaLibrary.Data.Entities.Universidad", "IdUniversidadNavigation")
                        .WithMany()
                        .HasForeignKey("IdUniversidad")
                        .HasConstraintName("FK_Universidad_Carrera")
                        .IsRequired();

                    b.Navigation("IdCarreraNavigation");

                    b.Navigation("IdUniversidadNavigation");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Usuario", b =>
                {
                    b.HasOne("UnlaLibrary.Data.Entities.TipoUsuario", "TipoUsuarioNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("TipoUsuario")
                        .HasConstraintName("FK_Usuario_TipoUsuario")
                        .IsRequired();

                    b.Navigation("TipoUsuarioNavigation");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.UsuarioMateria", b =>
                {
                    b.HasOne("UnlaLibrary.Data.Entities.Materia", "IdMateriaNavigation")
                        .WithMany()
                        .HasForeignKey("IdMateria")
                        .HasConstraintName("FK_Usuario_Materia")
                        .IsRequired();

                    b.HasOne("UnlaLibrary.Data.Entities.Usuario", "IdUsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Materia_Usuario")
                        .IsRequired();

                    b.Navigation("IdMateriaNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Idioma", b =>
                {
                    b.Navigation("MaterialEstudio");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Materia", b =>
                {
                    b.Navigation("MaterialEstudio");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.TipoUsuario", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("UnlaLibrary.Data.Entities.Usuario", b =>
                {
                    b.Navigation("MaterialEstudio");
                });
#pragma warning restore 612, 618
        }
    }
}
