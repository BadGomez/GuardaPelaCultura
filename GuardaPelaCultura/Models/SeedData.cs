using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class SeedData
    {
        internal static void Populate(GuardaPelaCulturaDbContext dbContext)
        {
            PopulateRestaurante(dbContext);
        }
        private static void PopulateRestaurante(GuardaPelaCulturaDbContext dbContext)
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
                    Imagem = null,
                    Imagem1 = null,
                    Imagem2 = null,
                    Imagem3 = null,
                });
            dbContext.SaveChanges();
        }
    }
}
