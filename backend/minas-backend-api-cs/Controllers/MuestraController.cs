/*
 * @fileoverview    {MuestraController}
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
    public class MuestraController : Controller
    {
        private readonly MinasContext _context;

        public MuestraController(MinasContext context)
        {
            _context = context;
        }

        // GET: Muestra
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muestra.ToListAsync());
        }

        // GET: Muestra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Muestra == null)
            {
                return NotFound();
            }

            var muestra = await _context.Muestra
                .FirstOrDefaultAsync(m => m.IntIdMuestra == id);
            if (muestra == null)
            {
                return NotFound();
            }

            return View(muestra);
        }

        // GET: Muestra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muestra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMuestra,StrPartida,StrCamion,DtFechaHora,StrObservaciones,StrRfid")] Muestra muestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muestra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muestra);
        }

        // GET: Muestra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Muestra == null)
            {
                return NotFound();
            }

            var muestra = await _context.Muestra.FindAsync(id);
            if (muestra == null)
            {
                return NotFound();
            }
            return View(muestra);
        }

        // POST: Muestra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdMuestra,StrPartida,StrCamion,DtFechaHora,StrObservaciones,StrRfid")] Muestra muestra)
        {
            if (id != muestra.IntIdMuestra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muestra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuestraExists(muestra.IntIdMuestra))
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
            return View(muestra);
        }

        // GET: Muestra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Muestra == null)
            {
                return NotFound();
            }

            var muestra = await _context.Muestra
                .FirstOrDefaultAsync(m => m.IntIdMuestra == id);
            if (muestra == null)
            {
                return NotFound();
            }

            return View(muestra);
        }

        // POST: Muestra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Muestra == null)
            {
                return Problem("Entity set 'MinasContext.Muestra'  is null.");
            }
            var muestra = await _context.Muestra.FindAsync(id);
            if (muestra != null)
            {
                _context.Muestra.Remove(muestra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuestraExists(int? id)
        {
            return _context.Muestra.Any(e => e.IntIdMuestra == id);
        }
    }
}
