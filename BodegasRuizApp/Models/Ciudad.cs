using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Ciudad
    {
        public Guid CiudadId { get; set; }
        public string Nombre { get; set; }
        public double MultiploCiudad { get; set; }
        public Guid ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public List<Usuario> Usuarios { get; set; }

    }
}
