using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BodegasRuizApp.Data;
using BodegasRuizApp.Models;

namespace BodegasRuizApp.Controllers
{
    public class FavoritosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favoritos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Favorito.Include(f => f.Usuario).Include(f=>f.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Favoritos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favorito
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.FavoritoId == id);
            if (favorito == null)
            {
                return NotFound();
            }

            return View(favorito);
        }

        // GET: Favoritos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Users, "ProductoId", "Nombre");
            return View();
        }

        // POST: Favoritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoritoId,FechaFavorito,FechaDesfavorito,EsFavorito,UsuarioId,ProductoId,Producto")] Favorito favorito)
        {
            if (ModelState.IsValid)
            {
                favorito.FavoritoId = Guid.NewGuid();
                _context.Add(favorito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Nombre", favorito.UsuarioId);
            ViewData["ProductoId"] = new SelectList(_context.Users, "ProductoId", "Nombre", favorito.ProductoId);
            return View(favorito);
        }

        // GET: Favoritos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favorito.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", favorito.UsuarioId);
            return View(favorito);
        }

        // POST: Favoritos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FavoritoId,FechaFavorito,FechaDesfavorito,EsFavorito,UsuarioId,ProductoId,Producto")] Favorito favorito)
        {
            if (id != favorito.FavoritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritoExists(favorito.FavoritoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", favorito.UsuarioId);
            return View(favorito);
        }

        // GET: Favoritos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorito = await _context.Favorito
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.FavoritoId == id);
            if (favorito == null)
            {
                return NotFound();
            }

            return View(favorito);
        }

        // POST: Favoritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var favorito = await _context.Favorito.FindAsync(id);
            _context.Favorito.Remove(favorito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritoExists(Guid id)
        {
            return _context.Favorito.Any(e => e.FavoritoId == id);
        }
    }
}
