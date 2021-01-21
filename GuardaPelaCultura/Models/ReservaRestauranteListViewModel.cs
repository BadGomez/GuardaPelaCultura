using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class ReservaRestauranteListViewModel
    {
       // public IIncludableQueryable<ReservasRestaurante> ReservaRestaurantes { get; set; }
       public IIncludableQueryable<ReservasRestaurante, Restaurantes>  ReservaRestaurantes { get; set; }
        
        public PagingInfo Paginacao { get; set; }

        public string SearchName { get; set; }
    }
}
