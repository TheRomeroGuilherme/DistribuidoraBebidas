using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistribuidoraAPI.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Distribuidora",
                newName: "NomeEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Distribuidora",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmailCorporativo",
                table: "Distribuidora",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidosFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistribuidoraId = table.Column<int>(type: "int", nullable: false),
                    ProdutoFornecedorId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosFornecedor_Distribuidora_DistribuidoraId",
                        column: x => x.DistribuidoraId,
                        principalTable: "Distribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosFornecedor_ProdutosFornecedor_ProdutoFornecedorId",
                        column: x => x.ProdutoFornecedorId,
                        principalTable: "ProdutosFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosFornecedor_DistribuidoraId",
                table: "PedidosFornecedor",
                column: "DistribuidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosFornecedor_ProdutoFornecedorId",
                table: "PedidosFornecedor",
                column: "ProdutoFornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosFornecedor");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Distribuidora");

            migrationBuilder.DropColumn(
                name: "EmailCorporativo",
                table: "Distribuidora");

            migrationBuilder.RenameColumn(
                name: "NomeEmpresa",
                table: "Distribuidora",
                newName: "Email");
        }
    }
}
