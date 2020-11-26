using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class RegistarMesa
    {
        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome tem de ter no mínimo 2 caracteres e no máximo 80")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Escreva o seu número de telefone por favor")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Escreva um endereço de email válido por favor")]
        [EmailAddress(ErrorMessage = "Please enter better.")]
        public string Email { get; set; }

        public int NumeroPessoas { get; set; }
    }
}

