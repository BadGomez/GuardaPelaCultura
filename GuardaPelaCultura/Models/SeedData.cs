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
            ListaRestaurantes(dbContext);
        }
    private static void ListaRestaurantes(GuardaPelaCulturaDbContext dbContext)
        {
            if (dbContext.Restaurantes.Any())
            {
                return;
            }
            dbContext.Restaurantes.AddRange(
                new Restaurantes
                {
                    NomeRestaurante = "Digujá",
                    NumeroTelefone = "987654321",
                    LocalizacaoRestaurante = "Guarda",
                    TextoDescritivoRestaurante = "Melhores Francesinhas da Guarda",
                    HoraAbertura = 10,
                    HoraFecho = 22,
                    Imagem = null,
                    Imagem1= null,
                    Imagem2= null,
                    Imagem3= null
                }
             );
            dbContext.SaveChanges();
        }
    }
}
