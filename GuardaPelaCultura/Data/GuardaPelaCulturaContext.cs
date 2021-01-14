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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var r in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                r.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }

        public GuardaPelaCulturaContext (DbContextOptions<GuardaPelaCulturaContext> options)
            : base(options)
        {
        }

        public DbSet<GuardaPelaCultura.Models.ReservasTakeAway> ReservasTakeAway { get; set; }

        public DbSet<GuardaPelaCultura.Models.Ementa> Produtos { get; set; }

        public DbSet<GuardaPelaCultura.Models.ReservasRestaurante> ReservasRestaurante { get; set; }

        public DbSet<GuardaPelaCultura.Models.Restaurantes> Restaurantes { get; set; }

        public DbSet<GuardaPelaCultura.Models.Cliente> Cliente { get; set; }

        public DbSet<GuardaPelaCultura.Models.Mesa> Mesa { get; set; }
    }
}
