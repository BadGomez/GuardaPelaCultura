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
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String NomeRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o Numero de Telefone!")]
        [StringLength(9, ErrorMessage = "O Numero de Telefone deve ter 9 números")]
        public String NumeroTelefone { get; set; }

        [Required(ErrorMessage = "É necessário Inserir o Numero de Lugares do Restaurante!")]
        public int LugaresRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário Inserir o Numero de Mesas do Restaurante")]
        public int MesasRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o Email do Restaurante!")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public String  EmailRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário a Localização do Restaurante!")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public String LocalizacaoRestaurante { get; set; }
    }
}
