using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class EmentaListViewModel
    {
        public IEnumerable<Ementa> Ementas { get; set; }
        public PagingInfo Pagination { get; set; }
        public string SearchName { get; set; }
    }
}
