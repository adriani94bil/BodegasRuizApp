using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Producto
    {
        public Guid ProductoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int CantidadTotal { get; set; }
        [Required]
        public double PrecioStd { get; set; }
        [Required]
        [Display(Name = "Dias en barrica")]
        public int DiasBarrica { get; set; }
        [Required]
        [Display(Name = "Año cosecha")]
        public string Añada { get; set; }
        [Required]
        [Display(Name="% alc.")]
        public double GradoAlc { get; set; }
        public string Foto { get; set; }
        [Required]
        [MaxLength(250)]
        [MinLength(30)]
        public string Descripcion { get; set; }
        public List<ProductoUbicacion> ListaProductoUbicacion { get; set; }
        public List<Compra> Compras { get; set; }
        public List<Favorito> Favoritos { get; set; }
        public List<Precio> Precios { get; set; }
    }
}
