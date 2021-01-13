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

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int RestaurantesId { get; set; }
        public Restaurantes Restaurantes { get; set; }
        
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        
        public int NumeroPessoas { get; set; }

        public bool Estado { get; set; }

        public string DataReserva { get; set; }

        [Required(ErrorMessage = "Escreva o seu número de telefone por favor")]
        [StringLength(9, ErrorMessage = "O telefone tem de ter 9 caracteres")]
        public string NumeroTelefoneReserva { get; set; }

        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome tem de ter no mínimo 2 caracteres e no máximo 80")]
        public string NomeReserva { get; set; }
        [Required(ErrorMessage = "É necessário o Texto Descritivo da Reserva!")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string DescricaoReserva{ get; set; }
    }
}
