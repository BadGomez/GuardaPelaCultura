using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class GuardaPelaCulturaDbContext : DbContext
    {
        public GuardaPelaCulturaDbContext(DbContextOptions options) : base(options) { }

        public DbSet <Restaurantes> Restaurantes { get; set; }
    }
}
