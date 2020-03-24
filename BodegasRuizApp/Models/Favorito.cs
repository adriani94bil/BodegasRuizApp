using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Favorito
    {
        public Guid FavoritoId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Favorito")]
        public DateTime FechaFavorito { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha quitar Favorito")]
        public DateTime FechaDesfavorito { get; set; }
        public bool EsFavorito { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid ProductoId { get; set; }
        public string Producto { get; set; }
    }
}
