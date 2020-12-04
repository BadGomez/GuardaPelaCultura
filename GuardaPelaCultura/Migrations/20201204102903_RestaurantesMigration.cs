using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class RestaurantesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestaurantesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRestaurante = table.Column<string>(maxLength: 1000, nullable: false),
                    NumeroTelefone = table.Column<string>(maxLength: 9, nullable: false),
                    LugaresRestaurante = table.Column<int>(nullable: false),
                    MesasRestaurante = table.Column<int>(nullable: false),
                    EmailRestaurante = table.Column<string>(nullable: false),
                    LocalizacaoRestaurante = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestaurantesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
