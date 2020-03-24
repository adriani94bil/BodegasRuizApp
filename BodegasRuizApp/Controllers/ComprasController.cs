using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BodegasRuizApp.Data;
using BodegasRuizApp.Models;
using BodegasRuizApp.Services;

namespace BodegasRuizApp.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Servicio _servicio;
        public ComprasController(ApplicationDbContext context, Servicio servicio)
        {
            _context = context;
            _servicio = servicio;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compra.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraId,OrdenCompra,CantidadComprada,FechaFavorito,UsuarioId,ProductoId,Producto")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                //Genero el string con el Po
                string po = _servicio.POGen();
                //Genero la fecha de compra
                DateTime fechaComp = DateTime.Now;
                //Mando los valores como view data
                ViewData["PO"] = po;
                ViewData["FECHA"] = fechaComp;
                compra.CompraId = Guid.NewGuid();
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CompraId,OrdenCompra,CantidadComprada,FechaFavorito,UsuarioId,ProductoId,Producto")] Compra compra)
        {
            if (id != compra.CompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.CompraId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var compra = await _context.Compra.FindAsync(id);
            _context.Compra.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(Guid id)
        {
            return _context.Compra.Any(e => e.CompraId == id);
        }
        // GET: Compras/CreatePO
        //public IActionResult CreatePO()
        //{
        //    return View();
        //}

        //// POST: Compras/CreatePO
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePO(Guid? producto, string cantidad)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Genero el string con el Po
        //        string po = _servicio.POGen();
        //        //Genero la fecha de compra
        //        DateTime fechaComp = DateTime.Now;
        //        //Cantidad comprada 
        //        int num = Convert.ToInt32(cantidad);

        //        compra.CompraId = Guid.NewGuid();
        //        _context.Add(compra);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(compra);
        //}
    }
}
