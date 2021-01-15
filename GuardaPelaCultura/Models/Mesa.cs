﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GuardaPelaCultura.Models
{
    public class Mesa
    {
        public int MesaId { get; set; }

        public int RestaurantesId { get; set; }

        public Restaurantes Restaurantes { get; set; }

        [Required(ErrorMessage = "É necessário Inserir o Numero de Lugares do Restaurante!")]
        public int LugaresRestaurante { get; set; }

        [Required(ErrorMessage = "É necessário Inserir o Numero de Mesas do Restaurante")]
        public int MesasRestaurante { get; set; }
    }
}
