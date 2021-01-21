using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class ReservaRestauranteListViewModel
    {
        public IEnumerable<ReservasRestaurante> ReservaRestaurantes { get; set; }

        public PagingInfo Paginacao { get; set; }

        public string SearchName { get; set; }
    }
}
