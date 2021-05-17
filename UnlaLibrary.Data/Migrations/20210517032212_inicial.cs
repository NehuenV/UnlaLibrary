using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnlaLibrary.Data.Migrations
{
    public partial class inicial : Migration
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
                    table.PrimaryKey("PK__Carrera__7B19E7913E1F87D6", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    idIdioma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idioma = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Idioma__A96571FC398F9DC2", x => x.idIdioma);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    idMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materia = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Materia__4B740AB3F639A85A", x => x.idMateria);
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
                    table.PrimaryKey("PK__TipoUsua__03006BFF287FB897", x => x.idTipoUsuario);
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
                    table.PrimaryKey("PK__Universi__AFB9D2244D38274E", x => x.idUniversidad);
                });

            migrationBuilder.CreateTable(
                name: "Carrera_Materia",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Carrera_Materia",
                        column: x => x.idCarrera,
                        principalTable: "Carrera",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materia_Carrera",
                        column: x => x.idMateria,
                        principalTable: "Materia",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialEstudio",
                columns: table => new
                {
                    idMateriaEstudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    idioma = table.Column<int>(type: "int", nullable: false),
                    materia = table.Column<int>(type: "int", nullable: false),
                    autor = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    archivo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__518559FD11C7A94B", x => x.idMateriaEstudio);
                    table.ForeignKey(
                        name: "FK_Idioma_MateriaEstudio",
                        column: x => x.idioma,
                        principalTable: "Idioma",
                        principalColumn: "idIdioma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materia_MateriaEstudio",
                        column: x => x.materia,
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
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    clave = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    tipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A6B1240B31", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario",
                        column: x => x.tipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Universidad_Carrera",
                columns: table => new
                {
                    idUniversidad = table.Column<int>(type: "int", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Carrera_Universidad",
                        column: x => x.idCarrera,
                        principalTable: "Carrera",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Universidad_Carrera",
                        column: x => x.idUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "idUniversidad",
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
                    table.ForeignKey(
                        name: "FK_Materia_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Materia",
                        column: x => x.idMateria,
                        principalTable: "Materia",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_Materia_idCarrera",
                table: "Carrera_Materia",
                column: "idCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_Materia_idMateria",
                table: "Carrera_Materia",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_idioma",
                table: "MaterialEstudio",
                column: "idioma");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEstudio_materia",
                table: "MaterialEstudio",
                column: "materia");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_Carrera_idCarrera",
                table: "Universidad_Carrera",
                column: "idCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_Carrera_idUniversidad",
                table: "Universidad_Carrera",
                column: "idUniversidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_tipoUsuario",
                table: "Usuario",
                column: "tipoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMateria_idMateria",
                table: "UsuarioMateria",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMateria_idUsuario",
                table: "UsuarioMateria",
                column: "idUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrera_Materia");

            migrationBuilder.DropTable(
                name: "MaterialEstudio");

            migrationBuilder.DropTable(
                name: "Universidad_Carrera");

            migrationBuilder.DropTable(
                name: "UsuarioMateria");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Universidad");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
