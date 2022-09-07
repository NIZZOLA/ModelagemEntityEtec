using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalAnuncios.Migrations
{
    public partial class historico2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidaturaHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidaturaId = table.Column<int>(type: "int", nullable: false),
                    DataDoStatus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidaturaHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidaturaHistorico_Candidatura_CandidaturaId",
                        column: x => x.CandidaturaId,
                        principalTable: "Candidatura",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidaturaHistorico_CandidaturaId",
                table: "CandidaturaHistorico",
                column: "CandidaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidaturaHistorico");
        }
    }
}
