using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cota_Usuario_LojaId",
                table: "Cota");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_LojaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CotaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Fachada",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "StatusDeAtualizacaoCadastral",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Usuario",
                newName: "PerfilDeAcesso");

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeDaLoja = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Fachada = table.Column<byte[]>(nullable: true),
                    Rua = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Numero = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Cep = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    StatusDeAtualizacaoCadastral = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cota_Loja_LojaId",
                table: "Cota",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cota_Loja_LojaId",
                table: "Cota");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_LojaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.RenameColumn(
                name: "PerfilDeAcesso",
                table: "Usuario",
                newName: "Telefone");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CotaId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Fachada",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StatusDeAtualizacaoCadastral",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cota_Usuario_LojaId",
                table: "Cota",
                column: "LojaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_LojaId",
                table: "Produto",
                column: "LojaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
