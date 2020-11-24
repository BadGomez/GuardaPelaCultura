using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Data.Migrations
{
    public partial class reservasTakeAwayMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasTakeAway",
                columns: table => new
                {
                    ReservasTakeAwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRestaurante = table.Column<string>(nullable: true),
                    NumeroTelefone = table.Column<string>(nullable: true),
                    Descrição = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasTakeAway", x => x.ReservasTakeAwayId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasTakeAway");
        }
    }
}
