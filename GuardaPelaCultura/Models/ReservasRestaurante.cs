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

        [Required(ErrorMessage ="Escreva o número de pessoas, com máximo 6 devido às restrições do covid!")]
        public int NumeroPessoas { get; set; }

        public bool EstadoReserva { get; set; }

        [Required(ErrorMessage = "É necessário indicar a data, para que seja possivel realizar a reserva!")]
        public DateTime DataReserva { get; set; }

        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string ObservacaoReserva { get; set; }
    }
}
