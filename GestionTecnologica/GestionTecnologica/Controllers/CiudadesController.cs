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
    public class CiudadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CiudadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Ciudad.Include(d => d.Departamento).ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .SingleOrDefaultAsync(m => m.IdCiudad == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            ViewBag.IdPais = new SelectList(_context.Pais, "IdPais", "Nombre");
            ViewBag.IdDepartamento = new SelectList(string.Empty, "IdDepartamento", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCiudad,Nombre,IdDepartamento, IdPais")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.IdPais = new SelectList(_context.Pais, "IdPais", "Nombre", ciudad.IdPais);
            ViewBag.IdDepartamento = new SelectList(_context.Departamento.Where(x => x.IdPais == ciudad.IdPais), "IdDepartamento", "Nombre", ciudad.IdDepartamento);
            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.SingleOrDefaultAsync(m => m.IdCiudad == id);
            var departamento = await _context.Departamento.SingleOrDefaultAsync(d => d.IdDepartamento == ciudad.IdCiudad);

            ViewBag.IdPais = new SelectList(_context.Pais, "IdPais", "Nombre", departamento.IdPais);
            ViewBag.IdDepartamento = new SelectList(_context.Departamento, "IdDepartamento", "Nombre", ciudad.IdDepartamento);
            
            if (ciudad == null)
            {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCiudad,Nombre,IdDepartamento,IdPais")] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
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
                    if (!CiudadExists(ciudad.IdCiudad))
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
            ViewBag.IdPais = new SelectList(_context.Pais, "IdPais", "Nombre", ciudad.IdPais);
            ViewBag.IdDepartamento = new SelectList(_context.Departamento.Where(x => x.IdPais == ciudad.IdPais), "IdDepartamento", "Nombre", ciudad.IdDepartamento);
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .SingleOrDefaultAsync(m => m.IdCiudad == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _context.Ciudad.SingleOrDefaultAsync(m => m.IdCiudad == id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudad.Any(e => e.IdCiudad == id);
        }

        public JsonResult GetDepartamentos(int idPais)
        {
            if (idPais > 0)
            {
                var departamentos = _context.Departamento.Where(x => x.IdPais == idPais).Select(x => new { x.IdDepartamento, x.Nombre }).ToList();
                return Json(departamentos);
            }
            else
            {
                var departamentos = _context.Departamento.Where(x => x.IdPais == 0).Select(x => new { x.IdDepartamento, x.Nombre }).ToList();
                return Json(departamentos);
            }
        }
    }
}
