using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSGFornecedor.infrastructure.Migrations
{
    public partial class FornecedorProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "Produto",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Produto");
        }
    }
}
