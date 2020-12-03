using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Data.Migrations
{
    public partial class ReservasTakeAwayaMigrationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "ReservasTakeAway",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ReservasTakeAway",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ReservasTakeAway");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "ReservasTakeAway",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
