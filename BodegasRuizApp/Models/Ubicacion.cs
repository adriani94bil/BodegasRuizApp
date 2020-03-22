using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Ubicacion
    {
        public Guid UbicacionId { get; set; }
        public string PosicionX { get; set; }
        public string PosicionY { get; set; }
        public List<ProductoUbicacion> UbicacionProducto { get; set; }
    }
}
