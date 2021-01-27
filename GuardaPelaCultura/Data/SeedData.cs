using GuardaPelaCultura.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Data
{
    public class SeedData
    {
        private const string DEFAULT_ADMIN_USER = "gestorGPC@gpc.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "GuardaPC27%";

        private const string ROLE_ADMINISTRADOR = "GestorGPC";
        private const string ROLE_GESTOR_RESTAURANTES = "GestorRestaurante";
        private const string ROLE_CLIENTE = "Cliente";

        internal static void Populate(GuardaPelaCulturaContext dbContext)
        {
            PopulateRestaurante(dbContext);
            PopulateMesa(dbContext);
        }
        private static void PopulateRestaurante(GuardaPelaCulturaContext dbContext)
        {
            if (dbContext.Restaurantes.Any())
            {
                return;
            }

            dbContext.Restaurantes.Add(
                new Restaurantes
                {
                    NomeRestaurante = "O Borges",
                    NumeroTelefone = "238313010",
                    EmailRestaurante = "oborges@gmail.com",
                    LocalizacaoRestaurante = "Tv. do Funchal 7, 6270-517 Seia",
                    TextoDescritivoRestaurante = "Localizado no centro de Seia. Restaurante com provas dadas na gastronomia regional",
                    HoraAbertura = 12,
                    HoraFecho = 22,
                    Imagem = File.ReadAllBytes("./imgSeed/OBorges.PNG"),
                    Imagem1 = File.ReadAllBytes("./imgSeed/OBorges1.jpg"),
                    Imagem2 = File.ReadAllBytes("./imgSeed/OBorges2.jpg"),
                    Imagem3 = File.ReadAllBytes("./imgSeed/OBorges3.jpg"),
                });
            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "Bola de Prata",
                NumeroTelefone = "271239169",
                EmailRestaurante = "boladeprata@gmail.com",
                LocalizacaoRestaurante = "R. Mouzinho da Silveira 16, 6300-663 Guarda",
                TextoDescritivoRestaurante = "Refeição muito bem confeccionada e muito saborosa! Doses bem servidas e com acompanhamentos variados!",
                HoraAbertura = 8,
                HoraFecho = 23,
                Imagem = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/BolaDePrata1.jpg"),
                Imagem2 = File.ReadAllBytes("./imgSeed/BolaDePrata2.jpg"),
                Imagem3 = File.ReadAllBytes("./imgSeed/BolaDePrata3.jpg"),
            });

            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "Belo Horizonte",
                NumeroTelefone = "271211454",
                EmailRestaurante = "restaurante_bh@hotmail.com",
                LocalizacaoRestaurante = "Largo de São Vicente 2, 6300-601 Guarda",
                TextoDescritivoRestaurante = "O Belo Horizonte é conhecido por ter uma ementa variada de bacalhaus, sendo que o bacalhau com natas é a especialidade da casa",
                HoraAbertura = 12,
                HoraFecho = 22,
                Imagem = File.ReadAllBytes("./imgSeed/BeloHorizonte1.jpg"),
                Imagem1 = File.ReadAllBytes("./imgSeed/BeloHorizonte2.jpg"),
                Imagem2 = File.ReadAllBytes("./imgSeed/BeloHorizonte3.jpg"),
                Imagem3 = File.ReadAllBytes("./imgSeed/BeloHorizonte4.jpg"),
            });

            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "Colmeia",
                NumeroTelefone = "271213389",
                EmailRestaurante = "geral@restaurantecolmeia.com",
                LocalizacaoRestaurante = "Estr. dos Galegos, 6300-653 Guarda",
                TextoDescritivoRestaurante = "A nossa carta procura ser direta e simples, tendo sempre por base os produtos da temporada.",
                HoraAbertura = 10,
                HoraFecho = 22,
                Imagem = File.ReadAllBytes("./imgSeed/Colmeia.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/Colmeia1.jpg"),
                Imagem2 = File.ReadAllBytes("./imgSeed/Colmeia2.jpg"),
                Imagem3 = File.ReadAllBytes("./imgSeed/Colmeia3.jpg"),
            });

            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "Cortelha da Burra",
                NumeroTelefone = "271225150",
                EmailRestaurante = "cortelhadaburra@hotmail.com",
                LocalizacaoRestaurante = "EM556, Mizarela",
                TextoDescritivoRestaurante = "O Restaurante Cortelha da Burra é um local onde os sabores tradicionais da Serra ganham nova dimensão!",
                HoraAbertura = 10,
                HoraFecho = 22,
                Imagem = File.ReadAllBytes("./imgSeed/CortelheiraDaBurra.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/cortelhaDaBurra1.jpg"),
                Imagem2 = File.ReadAllBytes("./imgSeed/cortelhaDaBurra2.jpg"),
                Imagem3 = File.ReadAllBytes("./imgSeed/cortelhaDaBurra3.jpg"),
            });

            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "DomGarfo",
                NumeroTelefone = "271211077",
                EmailRestaurante = "geral@domgarfo.pt",
                LocalizacaoRestaurante = "Bairro 25 de Abril 10, 6300-685 Guarda",
                TextoDescritivoRestaurante = "Em cada um destes segmentos a qualidade é Premium, pois para nós o “Garfo” é tratado por “Dom”. A nossa paixão é a cozinha, os alimentos e o serviço",
                HoraAbertura = 12,
                HoraFecho = 23,
                Imagem = File.ReadAllBytes("./imgSeed/DomGarfo.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/dom-garfo2.png"),
                Imagem2 = File.ReadAllBytes("./imgSeed/dom-garfo3.png"),
                Imagem3 = File.ReadAllBytes("./imgSeed/dom-garfo4.jpg"),
            });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "D'sigual",
                 NumeroTelefone = "271238046",
                 EmailRestaurante = "geral@dsigual.pt",
                 LocalizacaoRestaurante = "035, Lgo João de Almeida 11, Guarda",
                 TextoDescritivoRestaurante = "No Dsigual CoffeeDrinks encontra um local ideal para almoçar, jantar, partilhar um copo com os amigos e celebrar ocasiões especiais",
                 HoraAbertura = 10,
                 HoraFecho = 2,
                 Imagem = File.ReadAllBytes("./imgSeed/dsigual1.jpg"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/dsigual2.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/dsigual3.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/dsigual4.png"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "Fim do Mundo",
                 NumeroTelefone = "238089358",
                 EmailRestaurante = "pratoaescolha@gmail.com",
                 LocalizacaoRestaurante = "Av. dos Bombeiros Voluntários 60, 6270-434 Seia",
                 TextoDescritivoRestaurante = "Serviço de qualidade e simpatia.Ambiente moderno e acolhedor.",
                 HoraAbertura = 9,
                 HoraFecho = 2,
                 Imagem = File.ReadAllBytes("./imgSeed/fimdomundo.jpg"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/fimdomundo1.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/fimdomundo2.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/fimdomundo3.jpg"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "Guarda Rios",
                 NumeroTelefone = "238661115",
                 EmailRestaurante = "geral@guardarios.net",
                 LocalizacaoRestaurante = "Barriosa,Poço da Broca, Vide, Seia",
                 TextoDescritivoRestaurante = "Na bela e bucólica povoação de Barriosa, na freguesia de Vide, e a bordejar o Rio, encontra um dos mais belos restaurantes da Serra da Estrela.",
                 HoraAbertura = 11,
                 HoraFecho = 24,
                 Imagem = File.ReadAllBytes("./imgSeed/GuardaRios.PNG"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/GuardaRios1.jpeg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/GuardaRios2.jpeg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/GuardaRios3.jpg"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "Nobre vinhos & Tal",
                 NumeroTelefone = "961765480",
                 EmailRestaurante = "geral@nobrevinhosetal.com",
                 LocalizacaoRestaurante = "Largo Dr. Amândio Paúl nº5, 6300-664 Guarda",
                 TextoDescritivoRestaurante = "É do gosto pela simplicidade dos tesouros da gastronomia tradicional portuguesa associado ao gosto pelos vinhos que surge este espaço.",
                 HoraAbertura = 12,
                 HoraFecho = 24,
                 Imagem = File.ReadAllBytes("./imgSeed/NobreVinhosETal.PNG"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/nobreVinhosETal1.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/nobreVinhosETal2.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/nobreVinhosETal3.jpg"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "O Albertinho",
                 NumeroTelefone = "238745266",
                 EmailRestaurante = "oalbertino@sapo.pt",
                 LocalizacaoRestaurante = "Largo do, Adro de Viriato 8, 6290-081, folgosinho Gouveia",
                 TextoDescritivoRestaurante = "Os verdadeiros sabores da cozinha tradicional da Serra da Estrela. Uma experiência única que ficará na sua memória!",
                 HoraAbertura = 12,
                 HoraFecho = 22,
                 Imagem = File.ReadAllBytes("./imgSeed/OAlbertino1.PNG"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/OAlbertino2.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/OAlbertino3.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/OAlbertino4.jpg"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "O Galego",
                 NumeroTelefone = "271227328",
                 EmailRestaurante = "geral@restauranteogalego.pt",
                 LocalizacaoRestaurante = "Estrada dos Galegos, Guarda",
                 TextoDescritivoRestaurante = "Restaurante agradável com excelente comida e a preços acessíveis. O serviço é competente.",
                 HoraAbertura = 12,
                 HoraFecho = 24,
                 Imagem = File.ReadAllBytes("./imgSeed/OGalego1.jpg"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/OGalego2.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/OGalego3.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/OGalego4.jpg"),
             });

            dbContext.Restaurantes.Add(
             new Restaurantes
             {
                 NomeRestaurante = "Simple",
                 NumeroTelefone = "271212149",
                 EmailRestaurante = "ajrsribeiro@hotmail.com;",
                 LocalizacaoRestaurante = "R. Dr. Vasco Borges 20, 6300-771 Guarda",
                 TextoDescritivoRestaurante = " Gastronimia: Italiana, Piza, Internacional, Mediterrâneo, Contemporâneo, Saudável, Portuguesa",
                 HoraAbertura = 10,
                 HoraFecho = 22,
                 Imagem = File.ReadAllBytes("./imgSeed/simple1.PNG"),
                 Imagem1 = File.ReadAllBytes("./imgSeed/simple2.jpg"),
                 Imagem2 = File.ReadAllBytes("./imgSeed/simple3.jpg"),
                 Imagem3 = File.ReadAllBytes("./imgSeed/simple4.jpg"),
             });
            dbContext.SaveChanges();
        }
        private static void PopulateMesa(GuardaPelaCulturaContext dbContext)
        {
            /*dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 1,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 2,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
           /* dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 3,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 4,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 5,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 6,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 7,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 8,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 9,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 10,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 11,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 12,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });
            dbContext.Mesa.Add(
                new Mesa
                {
                    RestaurantesId = 13,
                    LugaresRestaurante = 4,
                    MesasRestaurante = 1,
                });*/

           // dbContext.SaveChanges();*/

        }

        internal static async Task SeedDefaultAdminAsync (UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRADOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if(user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if(!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRADOR);
            await EnsureRoleIsCreated(roleManager, ROLE_GESTOR_RESTAURANTES);
            await EnsureRoleIsCreated(roleManager, ROLE_CLIENTE);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "valter@ipg.pt", "Gestor123%", ROLE_GESTOR_RESTAURANTES);
            await EnsureUserIsCreated(userManager, "miguel@ipg.pt", "Pass123%", ROLE_CLIENTE);
        }

        internal static void SeedDevData(GuardaPelaCulturaContext db)
        {
            if (db.Cliente.Any()) return;

            db.Cliente.Add(new Cliente
            {
                NomeCliente = "Miguel",
                NumeroTelefoneCliente ="913132193",
                NifCliente = "232910325",
                EmailCliente = "miguel@ipg.pt"
            });

            db.SaveChanges();
        }
    }
}

//SEMPRE QUE ADICIONARMOS ALGO AQUI

//drop-database -Context GuardaPelaCulturaContext
//update-database -Context GuardaPelaCulturaContext

//utilizadores
//drop-Database -Context ApplicationDbContext
//update-Database -Context ApplicationDbContext
