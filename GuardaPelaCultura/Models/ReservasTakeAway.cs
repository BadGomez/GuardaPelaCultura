using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GuardaPelaCultura.Models
{
    public class ReservasTakeAway
    {
        public int ReservasTakeAwayId { get; set; }


        public string NomeRestaurante { get; set; }

        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome tem de ter no mínimo 2 caracteres e no máximo 80")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Escreva o seu número de telefone por favor")]
        public string NumeroTelefone { get; set; }

        public string Descricao { get; set; }
    }
}

