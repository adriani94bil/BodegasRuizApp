using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Compra
    {
        public Guid CompraId { get; set; }
        public string OrdenCompra { get; set; }
        public int CantidadComprada { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Compra")]
        public DateTime FechaFavorito { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid ProductoId { get; set; }
        public string Producto { get; set; }
    }
}
