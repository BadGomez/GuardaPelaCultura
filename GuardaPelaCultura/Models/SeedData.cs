using GuardaPelaCultura.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class SeedData
    {
        internal static void Populate(GuardaPelaCulturaContext dbContext)
        {
            PopulateRestaurante(dbContext);
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
                    NumeroTelefone = "914725836",
                    EmailRestaurante = "oborges@gmail.com",
                    LocalizacaoRestaurante = "Seia",
                    TextoDescritivoRestaurante = "Restaurante regional",
                    HoraAbertura = 11,
                    HoraFecho = 23,
                    Imagem = File.ReadAllBytes("./imgSeed/DomGarfo.PNG"),
                    Imagem1 = File.ReadAllBytes("./imgSeed/DomGarfo.PNG"),
                    Imagem2 = File.ReadAllBytes("./imgSeed/DomGarfo.PNG"),
                    Imagem3 = File.ReadAllBytes("./imgSeed/DomGarfo.PNG"),
                });
            dbContext.Restaurantes.Add(
            new Restaurantes
            {
                NomeRestaurante = "After",
                NumeroTelefone = "963725836",
                EmailRestaurante = "After@gmail.com",
                LocalizacaoRestaurante = "Guarda",
                TextoDescritivoRestaurante = "Espaço Acolheder",
                HoraAbertura = 11,
                HoraFecho = 20,
                Imagem = File.ReadAllBytes("./imgSeed/BolaDePrata.PNG"),
                Imagem1 = File.ReadAllBytes("./imgSeed/02.jpg"),
                Imagem2 = File.ReadAllBytes("./imgSeed/Colmeia.PNG"),
                Imagem3 = File.ReadAllBytes("./imgSeed/01.jpg"),
            });
            dbContext.SaveChanges();
        }
    }
}

//SEMPRE QUE ADICIONARMOS ALGO AQUI

//drop-database -Context GuardaPelaCulturaContext
//update-database -Context GuardaPelaCulturaContext