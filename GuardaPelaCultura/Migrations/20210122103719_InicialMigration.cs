using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuardaPelaCultura.Migrations
{
    public partial class InicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(maxLength: 80, nullable: false),
                    NumeroTelefoneCliente = table.Column<string>(maxLength: 14, nullable: false),
                    NifCliente = table.Column<string>(nullable: true),
                    EmailCliente = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ReservasTakeAway",
                columns: table => new
                {
                    ReservasTakeAwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRestaurante = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    NumeroTelefone = table.Column<string>(nullable: false),
                    ObservacaoTakeAway = table.Column<string>(nullable: true)
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
                    NomeRestaurante = table.Column<string>(maxLength: 100, nullable: false),
                    NumeroTelefone = table.Column<string>(maxLength: 14, nullable: false),
                    EmailRestaurante = table.Column<string>(maxLength: 40, nullable: false),
                    LocalizacaoRestaurante = table.Column<string>(maxLength: 100, nullable: false),
                    TextoDescritivoRestaurante = table.Column<string>(maxLength: 1000, nullable: false),
                    HoraAbertura = table.Column<int>(nullable: false),
                    HoraFecho = table.Column<int>(nullable: false),
                    Imagem = table.Column<byte[]>(nullable: true),
                    Imagem1 = table.Column<byte[]>(nullable: true),
                    Imagem2 = table.Column<byte[]>(nullable: true),
                    Imagem3 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestaurantesId);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    MesaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantesId = table.Column<int>(nullable: false),
                    LugaresRestaurante = table.Column<int>(nullable: false),
                    MesasRestaurante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.MesaId);
                    table.ForeignKey(
                        name: "FK_Mesa_Restaurantes_RestaurantesId",
                        column: x => x.RestaurantesId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestaurantesId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservasRestaurante",
                columns: table => new
                {
                    ReservasRestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantesId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MesaId = table.Column<int>(nullable: false),
                    NumeroPessoas = table.Column<int>(nullable: false),
                    EstadoReserva = table.Column<bool>(nullable: false),
                    DataReserva = table.Column<DateTime>(nullable: false),
                    ObservacaoReserva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasRestaurante", x => x.ReservasRestauranteId);
                    table.ForeignKey(
                        name: "FK_ReservasRestaurante_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservasRestaurante_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservasRestaurante_Restaurantes_RestaurantesId",
                        column: x => x.RestaurantesId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestaurantesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_RestaurantesId",
                table: "Mesa",
                column: "RestaurantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_RestaurantesId",
                table: "Produtos",
                column: "RestaurantesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasRestaurante_ClienteId",
                table: "ReservasRestaurante",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasRestaurante_MesaId",
                table: "ReservasRestaurante",
                column: "MesaId");

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
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
