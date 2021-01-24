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
            //byte[] foto = File.ReadAllBytes("./imgSeed/catedral.jpg");
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
                    /*Imagem = foto,
                    Imagem1 = foto,
                    Imagem2 = foto,
                    Imagem3 = foto,*/
                });
            dbContext.SaveChanges();
        }
    }
}
