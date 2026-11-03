using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KappukeekiApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precoUnitario",
                table: "ItensPedido",
                newName: "PrecoUnitario");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePessoa = table.Column<string>(type: "TEXT", nullable: false),
                    IdadePessoa = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailPessoa = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaHash = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaSalt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeSetor = table.Column<string>(type: "TEXT", nullable: false),
                    NivelPermissao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.IdSetor);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    HistoricoCliente = table.Column<string>(type: "TEXT", nullable: true),
                    InfoPagamento = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Pessoas_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFunc = table.Column<int>(type: "INTEGER", nullable: false),
                    DataContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Demitido = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFunc);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Pessoas_IdFunc",
                        column: x => x.IdFunc,
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Setores_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setores",
                        principalColumn: "IdSetor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdSetor",
                table: "Funcionarios",
                column: "IdSetor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ItensPedido",
                newName: "precoUnitario");
        }
    }
}
