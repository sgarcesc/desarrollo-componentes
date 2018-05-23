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
    public class TipoEquiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoEquiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoEquipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEquipo.ToListAsync());
        }

        // GET: TipoEquipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Habilitado")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo.SingleOrDefaultAsync(m => m.Id == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Habilitado")] TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEquipoExists(tipoEquipo.Id))
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
            return View(tipoEquipo);
        }

        // GET: TipoEquipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // POST: TipoEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEquipo = await _context.TipoEquipo.SingleOrDefaultAsync(m => m.Id == id);
            _context.TipoEquipo.Remove(tipoEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEquipoExists(int id)
        {
            return _context.TipoEquipo.Any(e => e.Id == id);
        }
    }
}
