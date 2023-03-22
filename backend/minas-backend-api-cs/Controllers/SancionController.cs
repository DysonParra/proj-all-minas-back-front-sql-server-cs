/*
 * @fileoverview    {SancionController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Minas.Data;
using Project.Models;

namespace Minas.Controllers
{
    public class SancionController : Controller
    {
        private readonly MinasContext _context;

        public SancionController(MinasContext context)
        {
            _context = context;
        }

        // GET: Sancion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sancion.ToListAsync());
        }

        // GET: Sancion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sancion == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sancion
                .FirstOrDefaultAsync(m => m.IntNumero == id);
            if (sancion == null)
            {
                return NotFound();
            }

            return View(sancion);
        }

        // GET: Sancion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sancion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntNumero,StrItem,BitSancionConductor,BitSancionVehiculo,StrTiempo")] Sancion sancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sancion);
        }

        // GET: Sancion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sancion == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sancion.FindAsync(id);
            if (sancion == null)
            {
                return NotFound();
            }
            return View(sancion);
        }

        // POST: Sancion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntNumero,StrItem,BitSancionConductor,BitSancionVehiculo,StrTiempo")] Sancion sancion)
        {
            if (id != sancion.IntNumero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SancionExists(sancion.IntNumero))
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
            return View(sancion);
        }

        // GET: Sancion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sancion == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sancion
                .FirstOrDefaultAsync(m => m.IntNumero == id);
            if (sancion == null)
            {
                return NotFound();
            }

            return View(sancion);
        }

        // POST: Sancion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Sancion == null)
            {
                return Problem("Entity set 'MinasContext.Sancion'  is null.");
            }
            var sancion = await _context.Sancion.FindAsync(id);
            if (sancion != null)
            {
                _context.Sancion.Remove(sancion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SancionExists(int? id)
        {
            return _context.Sancion.Any(e => e.IntNumero == id);
        }
    }
}
