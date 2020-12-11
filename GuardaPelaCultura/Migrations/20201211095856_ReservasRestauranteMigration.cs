using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class ReservasRestauranteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                table: "ReservasRestaurante");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantesId",
                table: "ReservasRestaurante",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                table: "ReservasRestaurante",
                column: "RestaurantesId",
                principalTable: "Restaurantes",
                principalColumn: "RestaurantesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                table: "ReservasRestaurante");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantesId",
                table: "ReservasRestaurante",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                table: "ReservasRestaurante",
                column: "RestaurantesId",
                principalTable: "Restaurantes",
                principalColumn: "RestaurantesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
