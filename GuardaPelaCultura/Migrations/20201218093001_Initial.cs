using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class Initial : Migration
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
                    LocalizacaoRestaurante = table.Column<string>(maxLength: 1000, nullable: false),
                    TextoDescritivoRestaurante = table.Column<string>(maxLength: 1000, nullable: false),
                    HorarioRestaurante = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestaurantesId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    EmentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmenta = table.Column<string>(maxLength: 1000, nullable: false),
                    DescricaoEmenta = table.Column<string>(nullable: true),
                    PrecoEmenta = table.Column<float>(nullable: false),
                    QuantidadeEmenta = table.Column<int>(nullable: false),
                    RestaurantesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.EmentaId);
                    table.ForeignKey(
                        name: "FK_Produtos_Restaurantes_RestaurantesId",
                        column: x => x.RestaurantesId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestaurantesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasRestaurante",
                columns: table => new
                {
                    ReservasRestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantesId = table.Column<int>(nullable: false),
                    NomeReserva = table.Column<string>(maxLength: 80, nullable: false),
                    NumeroPessoas = table.Column<int>(nullable: false),
                    NumeroTelefoneReserva = table.Column<string>(maxLength: 9, nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasRestaurante", x => x.ReservasRestauranteId);
                    table.ForeignKey(
                        name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                        column: x => x.RestaurantesId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestaurantesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_RestaurantesId",
                table: "Produtos",
                column: "RestaurantesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasRestaurante_RestaurantesId",
                table: "ReservasRestaurante",
                column: "RestaurantesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ReservasRestaurante");

            migrationBuilder.DropTable(
                name: "ReservasTakeAway");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
