using Microsoft.EntityFrameworkCore.Migrations;
using UnlaLibrary.Data.Utils;

namespace UnlaLibrary.Data.Migrations
{
    public partial class datos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
             typeof(datos)
             .Assembly
             .GetScript(
                 "UnlaLibrary.Data.Migrations.Scripts.datos.sql"));
            migrationBuilder.Sql(
            typeof(datos)
            .Assembly
            .GetScript(
                "UnlaLibrary.Data.Migrations.Scripts.insertMaterial.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
