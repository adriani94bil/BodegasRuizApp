using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BodegasRuizApp.Data;
using BodegasRuizApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BodegasRuizApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductoUbicacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoUbicacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoUbicaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductoUbicacion.Include(p => p.Producto).Include(p => p.Ubicacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductoUbicaciones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoUbicacion = await _context.ProductoUbicacion
                .Include(p => p.Producto)
                .Include(p => p.Ubicacion)
                .FirstOrDefaultAsync(m => m.ProductoUbicacionId == id);
            if (productoUbicacion == null)
            {
                return NotFound();
            }

            return View(productoUbicacion);
        }

        // GET: ProductoUbicaciones/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre");
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacion, "UbicacionId", "UbicacionId");
            return View();
        }

        // POST: ProductoUbicaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoUbicacionId,ProductoId,UbicacionId")] ProductoUbicacion productoUbicacion)
        {
            if (ModelState.IsValid)
            {
                productoUbicacion.ProductoUbicacionId = Guid.NewGuid();
                _context.Add(productoUbicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre", productoUbicacion.ProductoId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacion, "UbicacionId", "UbicacionId", productoUbicacion.UbicacionId);
            return View(productoUbicacion);
        }

        // GET: ProductoUbicaciones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoUbicacion = await _context.ProductoUbicacion.FindAsync(id);
            if (productoUbicacion == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre", productoUbicacion.ProductoId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacion, "UbicacionId", "UbicacionId", productoUbicacion.UbicacionId);
            return View(productoUbicacion);
        }

        // POST: ProductoUbicaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductoUbicacionId,ProductoId,UbicacionId")] ProductoUbicacion productoUbicacion)
        {
            if (id != productoUbicacion.ProductoUbicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoUbicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoUbicacionExists(productoUbicacion.ProductoUbicacionId))
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
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre" +
                "" +
                "", productoUbicacion.ProductoId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacion, "UbicacionId", "UbicacionId", productoUbicacion.UbicacionId);
            return View(productoUbicacion);
        }

        // GET: ProductoUbicaciones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoUbicacion = await _context.ProductoUbicacion
                .Include(p => p.Producto)
                .Include(p => p.Ubicacion)
                .FirstOrDefaultAsync(m => m.ProductoUbicacionId == id);
            if (productoUbicacion == null)
            {
                return NotFound();
            }

            return View(productoUbicacion);
        }

        // POST: ProductoUbicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productoUbicacion = await _context.ProductoUbicacion.FindAsync(id);
            _context.ProductoUbicacion.Remove(productoUbicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoUbicacionExists(Guid id)
        {
            return _context.ProductoUbicacion.Any(e => e.ProductoUbicacionId == id);
        }
    }
}
