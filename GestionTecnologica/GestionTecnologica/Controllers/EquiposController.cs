using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionTecnologica.Data;
using GestionTecnologica.Models;

namespace GestionTecnologica.Controllers
{
    public class EquiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipo.Include(e => e.TipoEquipo).Include(e => e.Sede);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.TipoEquipo)
                .Include(e => e.Sede)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            ViewBag.IdTipoEquipo = new SelectList(_context.TipoEquipo, "Id", "Nombre");
            ViewBag.IdSede = new SelectList(_context.Sede, "Id", "Direccion");
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroSerie,IdTipoEquipo,IdSede,FechaCompra,FechaExpiracionGarantia")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdTipoEquipo = new SelectList(_context.TipoEquipo, "Id", "Nombre", equipo.IdTipoEquipo);
            ViewBag.IdSede = new SelectList(_context.Sede, "Id", "Direccion", equipo.IdSede);
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.SingleOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroSerie,IdTipoEquipo,IdSede,FechaCompra,FechaExpiracionGarantia")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipo.SingleOrDefaultAsync(m => m.Id == id);
            _context.Equipo.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }

        // GET: Equipos/Informe
        public async Task<IActionResult> Informe()
        {
            var equipo = await _context.Equipo
                .Include(e => e.TipoEquipo)
                .Include(e => e.Sede)
                .Where(x => x.FechaExpiracionGarantia <= DateTime.Now).ToListAsync();

            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }
    }
}
