using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MATRICULA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DATAADMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMPRESAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Funcionario_EMPRESA_EMPRESAID",
                        column: x => x.EMPRESAID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_CNPJ",
                table: "EMPRESA",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_RAZAOSOCIAL",
                table: "EMPRESA",
                column: "RAZAOSOCIAL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EMPRESAID",
                table: "Funcionario",
                column: "EMPRESAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "EMPRESA");
        }
    }
}
