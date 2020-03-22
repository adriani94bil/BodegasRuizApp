using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Provincia
    {
        public Guid ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public double MultiploProvincia { get; set; }
        public List<Ciudad> Ciudades { get; set; }

    }
}
