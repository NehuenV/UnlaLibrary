using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnlaLibrary.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrera = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    idIdioma = table.Column<int>(type: "int", nullable: false),
                    idioma = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.idIdioma);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    idMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.idMateria);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipoUsuario = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    idUniversidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUniversidad = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.idUniversidad);
                });

            migrationBuilder.CreateTable(
                name: "CarreraMateria",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraMateria", x => new { x.idCarrera, x.idMateria });
                    table.ForeignKey(
                        name: "FK_CarreraMateria_Carrera",
                        column: x => x.idCarrera,
                        principalTable: "Carrera",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarreraMateria_Materia",
                        column: x => x.idMateria,
                        principalTable: "Materia",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    apellido = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    dni = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    clave = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniversidadCarrera",
                columns: table => new
                {
                    idUniversidad = table.Column<int>(type: "int", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversidadCarrera", x => new { x.idUniversidad, x.idCarrera });
                    table.ForeignKey(
                        name: "FK_UniversidadCarrera_Carrera",
                        column: x => x.idCarrera,
                        principalTable: "Carrera",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversidadCarrera_Universidad",
                        column: x => x.idUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "idUniversidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialEstudio",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    prologo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    autor = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    archivo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    miniatura = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    idIdioma = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false),
                    idUniversidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialEstudio", x => x.IdMaterial);
                    table.ForeignKey(
                        name: "FK_MaterialEstudio_Idioma",
                        column: x => x.idIdioma,
                        principalTable: "Idioma",
                        principalColumn: "idIdioma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialEstudio_Materia",
                        column: x => x.idMateria,
                        principalTable: "Materia",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialEstudio_Universidad",
                        column: x => x.idUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "idUniversidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialEstudio_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCarreraUniversidad",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    idUniversidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCarreraUniversidad", x => new { x.idUsuario, x.idCarrera, x.idUniversidad });
                    table.ForeignKey(
                        name: "FK_UsuarioCarreraUniversidad_Carrera",
                        column: x => x.idCarrera,
                        principalTable: "Carrera",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioCarreraUniversidad_Universidad",
                        column: x => x.idUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "idUniversidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioCarreraUniversidad_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMateria",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMateria", x => new { x.idUsuario, x.idMateria });
                    table.ForeignKey(
                        name: "FK_UsuarioMateria_Materia",
                        column: x => x.idMateria,
                        principalTable: "Materia",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioMateria_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reseña",
                columns: table => new
                {
                    idReseña = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comentario = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    puntuacion = table.Column<int>(type: "int", nullable: false),
                    idMaterial = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseña", x => x.idReseña);
                    table.ForeignKey(
                        name: "FK_Reseña_MaterialEstudio",
                        column: x => x.idMaterial,
                        principalTable: "MaterialEstudio",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reseña_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarreraMateria_idMateria",
                table: "CarreraMateria",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_idIdioma",
                table: "MaterialEstudio",
                column: "idIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_idMateria",
                table: "MaterialEstudio",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_idUniversidad",
                table: "MaterialEstudio",
                column: "idUniversidad");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_idUsuario",
                table: "MaterialEstudio",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reseña_idMaterial",
                table: "Reseña",
                column: "idMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Reseña_idUsuario",
                table: "Reseña",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UniversidadCarrera_idCarrera",
                table: "UniversidadCarrera",
                column: "idCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCarreraUniversidad_idCarrera",
                table: "UsuarioCarreraUniversidad",
                column: "idCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCarreraUniversidad_idUniversidad",
                table: "UsuarioCarreraUniversidad",
                column: "idUniversidad");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMateria_idMateria",
                table: "UsuarioMateria",
                column: "idMateria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarreraMateria");

            migrationBuilder.DropTable(
                name: "Reseña");

            migrationBuilder.DropTable(
                name: "UniversidadCarrera");

            migrationBuilder.DropTable(
                name: "UsuarioCarreraUniversidad");

            migrationBuilder.DropTable(
                name: "UsuarioMateria");

            migrationBuilder.DropTable(
                name: "MaterialEstudio");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Universidad");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
