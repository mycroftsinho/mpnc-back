using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CotaId = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Cota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LojaId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cota_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LojaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cota_LojaId",
                table: "Cota",
                column: "LojaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_LojaId",
                table: "Produto",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cota");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Loja");
        }
    }
}
