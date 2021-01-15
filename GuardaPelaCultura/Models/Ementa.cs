using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GuardaPelaCultura.Models
{
    public class Ementa
    {
        public int EmentaId { get; set; }

        [Required(ErrorMessage = "É necessário o Nome da Ementa!")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres")]
        public string NomeEmenta { get; set; }

        public string DescricaoEmenta { get; set; }

        [Required(ErrorMessage = "É necessário Inserir um Preço")]
        public float PrecoEmenta { get; set; }

        [Required(ErrorMessage = "É necessário Inserir a Quantidade Disponível!")]
        public int QuantidadeEmenta { get; set; }

        public int RestaurantesId { get; set; }

        public Restaurantes Restaurantes { get; set; }
    }
}
