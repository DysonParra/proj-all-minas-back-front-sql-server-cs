/*
 * @fileoverview    {OrigenController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
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

namespace Minas.Controllers {

    /**
     * TODO: Description of {@code OrigenController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class OrigenController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code OrigenController}.
         *
         */
        public OrigenController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Origen
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Origen.ToListAsync());
        }

        /**
         * GET: Origen/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Origen == null) {
                return NotFound();
            }

            var origen = await _context.Origen
                .FirstOrDefaultAsync(m => m.StrIdOrigen == id);
            if (origen == null) {
                return NotFound();
            }

            return View(origen);
        }

        /**
         * GET: Origen/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Origen/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrIdOrigen,StrNombre,StrCodigoRfid,StrDireccion,StrObservaciones")] Origen origen) {
            if (ModelState.IsValid) {
                _context.Add(origen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origen);
        }

        /**
         * GET: Origen/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Origen == null) {
                return NotFound();
            }

            var origen = await _context.Origen.FindAsync(id);
            if (origen == null) {
                return NotFound();
            }
            return View(origen);
        }

        /**
         * POST: Origen/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrIdOrigen,StrNombre,StrCodigoRfid,StrDireccion,StrObservaciones")] Origen origen) {
            if (id != origen.StrIdOrigen) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(origen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!OrigenExists(origen.StrIdOrigen)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(origen);
        }

        /**
         * GET: Origen/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Origen == null) {
                return NotFound();
            }

            var origen = await _context.Origen
                .FirstOrDefaultAsync(m => m.StrIdOrigen == id);
            if (origen == null) {
                return NotFound();
            }

            return View(origen);
        }

        /**
         * POST: Origen/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Origen == null) {
                return Problem("Entity set 'MinasContext.Origen'  is null.");
            }
            var origen = await _context.Origen.FindAsync(id);
            if (origen != null) {
                _context.Origen.Remove(origen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code OrigenExists}.
         *
         */
        private bool OrigenExists(string id) {
            return _context.Origen.Any(e => e.StrIdOrigen == id);
        }
    }
}
