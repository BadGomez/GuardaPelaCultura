using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class RestaurantesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HorarioRestaurante",
                table: "Restaurantes",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextoDescritivoRestaurante",
                table: "Restaurantes",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "ReservasRestaurante",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ReservasRestaurante",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioRestaurante",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "TextoDescritivoRestaurante",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ReservasRestaurante");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "ReservasRestaurante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9);
        }
    }
}
