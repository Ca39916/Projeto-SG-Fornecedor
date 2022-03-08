using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSGFornecedor.infrastructure.Migrations
{
    public partial class IdCategoriaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoria",
                table: "Produto",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
