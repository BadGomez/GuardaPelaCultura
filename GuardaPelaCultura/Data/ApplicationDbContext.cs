using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Models;

namespace GuardaPelaCultura.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /*public DbSet<GuardaPelaCultura.Models.ReservasRestaurante> ReservasRestaurante { get; set; }
        public DbSet<GuardaPelaCultura.Models.ReservasTakeAway> ReservasTakeAway { get; set; }
        public DbSet<GuardaPelaCultura.Models.Ementa> Produtos { get; set; }*/
    }
}
