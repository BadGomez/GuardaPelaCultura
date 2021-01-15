using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class IGuardaPelaCulturaRepository
    {
        public IEnumerable<Restaurantes> restaurantes { get; }
    }
}
