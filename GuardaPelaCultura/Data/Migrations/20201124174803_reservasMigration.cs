using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Data.Migrations
{
    public partial class reservasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasRestaurante",
                columns: table => new
                {
                    ReservasRestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRestaurante = table.Column<string>(nullable: true),
                    NumeroTelefone = table.Column<string>(nullable: true),
                    Descrição = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasRestaurante", x => x.ReservasRestauranteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasRestaurante");
        }
    }
}
