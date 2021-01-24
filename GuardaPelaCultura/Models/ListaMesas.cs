using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class ListaMesas
    {
        public IIncludableQueryable<Mesa, Restaurantes> Mesa { get; set; }

        public PagingInfo Paginacao { get; set; }

        public string SearchMesa { get; set; }
    }
}
