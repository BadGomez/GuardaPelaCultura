using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaPelaCultura.Models
{
    public class EditLoggedInClienteViewModel
    {
        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome tem de ter no mínimo 2 caracteres e no máximo 80")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Escreva o seu número de telefone por favor")]
        [StringLength(14, ErrorMessage = "O telefone tem de ter 14 caracteres")]
        public string NumeroTelefoneCliente { get; set; }

        public string NifCliente { get; set; }

        [Required(ErrorMessage = "É necessário o seu Email por favor")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [StringLength(40, ErrorMessage = "O Email deve ter 40 caracteres")]
        public string EmailCliente { get; set; }
    }
}
