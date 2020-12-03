using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class ReservasTakeAwayMigration : Migration
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
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    NumeroTelefone = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
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
