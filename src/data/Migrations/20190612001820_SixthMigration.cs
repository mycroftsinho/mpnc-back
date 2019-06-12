using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Loja");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LojaId = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Numero = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Cep = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_LojaId",
                table: "Endereco",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
