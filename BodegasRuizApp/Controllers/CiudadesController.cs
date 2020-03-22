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
    //Solo el administrador puede generar ciudades
    //[Authorize(Roles = "admin")]
    public class CiudadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CiudadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ciudad.Include(c => c.Provincia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.Provincia)
                .FirstOrDefaultAsync(m => m.CiudadId == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiudadId,Nombre,MultiploCiudad,ProvinciaId")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                ciudad.CiudadId = Guid.NewGuid();
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Nombre", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Nombre", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CiudadId,Nombre,MultiploCiudad,ProvinciaId")] Ciudad ciudad)
        {
            if (id != ciudad.CiudadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadExists(ciudad.CiudadId))
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
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Nombre", ciudad.ProvinciaId);
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.Provincia)
                .FirstOrDefaultAsync(m => m.CiudadId == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(Guid id)
        {
            return _context.Ciudad.Any(e => e.CiudadId == id);
        }
    }
}
