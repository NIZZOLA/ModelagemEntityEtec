using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalAnuncios.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncianteId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncios_Clientes_AnuncianteId",
                        column: x => x.AnuncianteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientesEnderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEnderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidaturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(type: "int", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidaturas_Anuncios_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidaturas_Clientes_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidaturas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidaturasHistoricos",
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
                    table.PrimaryKey("PK_CandidaturasHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidaturasHistoricos_Candidaturas_CandidaturaId",
                        column: x => x.CandidaturaId,
                        principalTable: "Candidaturas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_AnuncianteId",
                table: "Anuncios",
                column: "AnuncianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_AnuncioId",
                table: "Candidaturas",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_CandidatoId",
                table: "Candidaturas",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_ClienteId",
                table: "Candidaturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidaturasHistoricos_CandidaturaId",
                table: "CandidaturasHistoricos",
                column: "CandidaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEnderecos_ClienteId",
                table: "ClientesEnderecos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidaturasHistoricos");

            migrationBuilder.DropTable(
                name: "ClientesEnderecos");

            migrationBuilder.DropTable(
                name: "Candidaturas");

            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
