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
    }
}
