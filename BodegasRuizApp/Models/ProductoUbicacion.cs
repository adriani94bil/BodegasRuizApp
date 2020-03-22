using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class ProductoUbicacion
    {
        public Guid ProductoUbicacionId { get; set; }
        public Guid ProductoId { get; set; }
        public Producto Producto { get; set; }
        public Guid UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }

    }
}
