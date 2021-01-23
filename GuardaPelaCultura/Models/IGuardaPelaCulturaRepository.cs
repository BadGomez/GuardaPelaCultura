using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    interface IGuardaPelaCulturaRepository
    {
        public IEnumerable<Restaurantes> Restaurantes {get;}
    }
}
