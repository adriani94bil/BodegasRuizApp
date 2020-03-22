using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Precio
    {
        public Guid PrecioId { get; set; }
        public double PrecioFinal { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid ProductoId { get; set; }
        public string Producto { get; set; }


    }
}
