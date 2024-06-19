using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoDeCaixa.Infra.Repository.Mysql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Saldo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoLancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLancamentos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CaixaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TipoLancamentoId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacoes_TipoLancamentos_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TipoLancamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Caixas",
                columns: new[] { "Id", "Ativo", "DataAtualizacao", "DataCadastro", "Nome", "Saldo" },
                values: new object[] { new Guid("5c4a3177-785e-44c0-b21b-fc54ddb64976"), true, null, new DateTime(2024, 6, 18, 2, 35, 43, 516, DateTimeKind.Local).AddTicks(6365), "Caixa1", 0m });

            migrationBuilder.InsertData(
                table: "TipoLancamentos",
                columns: new[] { "Id", "Ativo", "DataCadastro", "Descricao" },
                values: new object[] { 1, true, new DateTime(2024, 6, 18, 2, 35, 43, 516, DateTimeKind.Local).AddTicks(6456), "Crédito" });

            migrationBuilder.InsertData(
                table: "TipoLancamentos",
                columns: new[] { "Id", "Ativo", "DataCadastro", "Descricao" },
                values: new object[] { 2, true, new DateTime(2024, 6, 18, 2, 35, 43, 516, DateTimeKind.Local).AddTicks(6458), "Débito" });

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_Id",
                table: "Caixas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_CaixaId",
                table: "Transacoes",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_Id",
                table: "Transacoes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_TipoLancamentoId",
                table: "Transacoes",
                column: "TipoLancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropTable(
                name: "TipoLancamentos");
        }
    }
}
