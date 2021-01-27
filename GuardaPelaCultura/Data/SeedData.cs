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
                NumeroTelefone = "963725836",
                EmailRestaurante = "After@gmail.com",
                LocalizacaoRestaurante = "Guarda",
                TextoDescritivoRestaurante = "Espaço Acolheder",
                HoraAbertura = 11,
                HoraFecho = 20,
                Imagem = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
                Imagem2 = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
                Imagem3 = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
            });
            dbContext.SaveChanges();
        }
        private static void PopulateMesa(GuardaPelaCulturaContext dbContext)
        {
            dbContext.Mesa.Add(
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
                    LugaresRestaurante = 5,
                    MesasRestaurante = 1,
                });
            dbContext.SaveChanges();

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
