using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Models;

namespace GuardaPelaCultura.Data
{
    public class GuardaPelaCulturaContext : DbContext
    {
        public GuardaPelaCulturaContext (DbContextOptions<GuardaPelaCulturaContext> options)
            : base(options)
        {
        }

        public DbSet<GuardaPelaCultura.Models.ReservasTakeAway> ReservasTakeAway { get; set; }

        public DbSet<GuardaPelaCultura.Models.Ementa> Produtos { get; set; }

        public DbSet<GuardaPelaCultura.Models.ReservasRestaurante> ReservasRestaurante { get; set; }

        public DbSet<GuardaPelaCultura.Models.Restaurantes> Restaurantes { get; set; }

        public DbSet<GuardaPelaCultura.Models.Cliente> Cliente { get; set; }
    }
}
