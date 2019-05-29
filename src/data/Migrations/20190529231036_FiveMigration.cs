using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class FiveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeDaLoja",
                table: "Loja",
                newName: "Representante");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Loja",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Loja");

            migrationBuilder.RenameColumn(
                name: "Representante",
                table: "Loja",
                newName: "NomeDaLoja");
        }
    }
}
