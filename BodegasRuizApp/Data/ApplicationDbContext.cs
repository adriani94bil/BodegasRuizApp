using System;
using System.Collections.Generic;
using System.Text;
using BodegasRuizApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BodegasRuizApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BodegasRuizApp.Models.Ciudad> Ciudad { get; set; }
        public DbSet<BodegasRuizApp.Models.Provincia> Provincia { get; set; }
        public DbSet<BodegasRuizApp.Models.Ubicacion> Ubicacion { get; set; }
        public DbSet<BodegasRuizApp.Models.Producto> Producto { get; set; }
        public DbSet<BodegasRuizApp.Models.ProductoUbicacion> ProductoUbicacion { get; set; }
        public DbSet<BodegasRuizApp.Models.Compra> Compra { get; set; }
        public DbSet<BodegasRuizApp.Models.Favorito> Favorito { get; set; }
    }
}
