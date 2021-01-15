using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class EntityFrameWorkRepository : IGuardaPelaCulturaRepository
    {
        private GuardaPelaCulturaDbContext dbContext;

        public EntityFrameWorkRepository(GuardaPelaCulturaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Restaurantes> Restaurantes => dbContext.Restaurantes;
    }
}
