using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GuardaPelaCultura.Models
{
    public class ReservasRestaurante
    {
        public int ReservasRestauranteId { get; set; }

        public int RestaurantesId { get; set; }

        public Restaurantes Restaurantes { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }

        [Required]
        public int NumeroPessoas { get; set; }

        public bool EstadoReserva { get; set; }

        [Required]
        public string DataReserva { get; set; }

        public string ObservacaoReserva { get; set; }
    }
}
