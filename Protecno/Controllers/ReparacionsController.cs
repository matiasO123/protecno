using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Protecno.Models;

namespace Protecno.Controllers
{
    public class ReparacionsController : Controller
    {
        private readonly AppDbContext _context;

        public ReparacionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reparacions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.reparacions.Include(r => r.Producto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Reparacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.reparacions
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparacion == null)
            {
                return NotFound();
            }

            return View(reparacion);
        }

        // GET: Reparacions/Create
        public IActionResult Create()
        {
            ViewData["productoID"] = new SelectList(_context.productos, "Id", "Id");
            return View();
        }

        // POST: Reparacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fechaAlta,fechaFinalizacion,estadoReparacion,precio,productoID")] Reparacion reparacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productoID"] = new SelectList(_context.productos, "Id", "Id", reparacion.productoID);
            return View(reparacion);
        }

        // GET: Reparacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.reparacions.FindAsync(id);
            if (reparacion == null)
            {
                return NotFound();
            }
            ViewData["productoID"] = new SelectList(_context.productos, "Id", "Id", reparacion.productoID);
            return View(reparacion);
        }

        // POST: Reparacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fechaAlta,fechaFinalizacion,estadoReparacion,precio,productoID")] Reparacion reparacion)
        {
            if (id != reparacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparacionExists(reparacion.Id))
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
            ViewData["productoID"] = new SelectList(_context.productos, "Id", "Id", reparacion.productoID);
            return View(reparacion);
        }

        // GET: Reparacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.reparacions
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparacion == null)
            {
                return NotFound();
            }

            return View(reparacion);
        }

        // POST: Reparacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparacion = await _context.reparacions.FindAsync(id);
            if (reparacion != null)
            {
                _context.reparacions.Remove(reparacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparacionExists(int id)
        {
            return _context.reparacions.Any(e => e.Id == id);
        }
    }
}
