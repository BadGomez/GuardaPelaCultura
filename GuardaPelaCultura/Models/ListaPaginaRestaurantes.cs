using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class ListaPaginaRestaurantes
    {
        public IEnumerable<Restaurantes> ListaRestaurantes { get; set; }

        public PagingInfo Paginacao { get; set; }

        public string SearchName { get; set; }
    }
}
