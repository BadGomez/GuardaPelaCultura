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

        public int RestauranteID { get; set; }

        public Restaurantes Restaurantes { get; set; }

        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome tem de ter no mínimo 2 caracteres e no máximo 80")]
        public string NomeReserva { get; set; }

        public int NumeroPessoas { get; set; }

        [Required(ErrorMessage = "Escreva o seu número de telefone por favor")]
        [StringLength(9, ErrorMessage = "O telefone tem de ter 9 caracteres")]
        public string  NumeroTelefoneReserva { get; set; }

        public string Descricao { get; set; }
    }
}
