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

        [Required(ErrorMessage = "É necessário o Nome do Populate!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string NomeRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o Numero de Telefone!")]
        [StringLength(14, ErrorMessage = "O Numero de Telefone deve ter 14 números")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "É necessário o Email do Populate!")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [StringLength(40, ErrorMessage = "O Email deve ter 40 caracteres")]
        public string  EmailRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário a Localização do Populate!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string LocalizacaoRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário o TextoDescritivo do Populate!")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string TextoDescritivoRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário escolher a Hora de Abertura")]
        public int HoraAbertura { get; set; }

        [Required(ErrorMessage = "É necessário escolher a Hora de Fecho")]
        public int HoraFecho { get; set; }

        public byte[] Imagem { get; set; }

        public byte[] Imagem1 { get; set; }

        public byte[] Imagem2 { get; set; }

        public byte[] Imagem3 { get; set; }
    }
}
