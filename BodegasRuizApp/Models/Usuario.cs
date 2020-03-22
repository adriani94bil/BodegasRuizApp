using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Models
{
    public class Usuario:IdentityUser
    {
        //Ojo que el Id va a ser un string
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public Guid CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public List<Compra> Compras { get; set; }
        public List<Favorito> Favoritos { get; set; }
        public List<Precio> Precios { get; set; }

    }
}
