using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalAnuncios.Migrations
{
    public partial class alteranome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cliente",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Anuncio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Anuncio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Anuncio");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Anuncio");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cliente",
                newName: "Name");
        }
    }
}
