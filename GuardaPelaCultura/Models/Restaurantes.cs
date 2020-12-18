using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GuardaPelaCultura.Models
{
    public class Restaurantes
    {
        public int RestaurantesId { get; set; }

        [Required(ErrorMessage = "É necessário o Nome do Restaurante!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String NomeRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o Numero de Telefone!")]
        [StringLength(14, ErrorMessage = "O Numero de Telefone deve ter 14 números")]
        public String NumeroTelefone { get; set; }

        [Required(ErrorMessage = "É necessário o Email do Restaurante!")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [StringLength(40, ErrorMessage = "O Email deve ter 40 caracteres")]
        public String  EmailRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário a Localização do Restaurante!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String LocalizacaoRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o TextoDescritivo do Restaurante!")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String TextoDescritivoRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o Horário de Funcionamento do Restaurante!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String HorarioRestaurante { get; set; }
    }
}
