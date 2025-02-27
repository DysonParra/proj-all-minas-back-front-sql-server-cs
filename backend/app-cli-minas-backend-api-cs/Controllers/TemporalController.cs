/*
 * @fileoverview    {TemporalController}
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
     * TODO: Description of {@code TemporalController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TemporalController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code TemporalController}.
         *
         */
        public TemporalController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Temporal
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Temporal.ToListAsync());
        }

        /**
         * GET: Temporal/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Temporal == null) {
                return NotFound();
            }

            var temporal = await _context.Temporal
                .FirstOrDefaultAsync(m => m.IntIdTemporal == id);
            if (temporal == null) {
                return NotFound();
            }

            return View(temporal);
        }

        /**
         * GET: Temporal/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Temporal/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTemporal,StrPlaca,StrRfid,StrProveedor,StrTope,IntAcumulado,DtFechaEntrada,DtFechaSalida,StrEstado")] Temporal temporal) {
            if (ModelState.IsValid) {
                _context.Add(temporal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temporal);
        }

        /**
         * GET: Temporal/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Temporal == null) {
                return NotFound();
            }

            var temporal = await _context.Temporal.FindAsync(id);
            if (temporal == null) {
                return NotFound();
            }
            return View(temporal);
        }

        /**
         * POST: Temporal/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdTemporal,StrPlaca,StrRfid,StrProveedor,StrTope,IntAcumulado,DtFechaEntrada,DtFechaSalida,StrEstado")] Temporal temporal) {
            if (id != temporal.IntIdTemporal) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(temporal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TemporalExists(temporal.IntIdTemporal)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(temporal);
        }

        /**
         * GET: Temporal/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Temporal == null) {
                return NotFound();
            }

            var temporal = await _context.Temporal
                .FirstOrDefaultAsync(m => m.IntIdTemporal == id);
            if (temporal == null) {
                return NotFound();
            }

            return View(temporal);
        }

        /**
         * POST: Temporal/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Temporal == null) {
                return Problem("Entity set 'MinasContext.Temporal'  is null.");
            }
            var temporal = await _context.Temporal.FindAsync(id);
            if (temporal != null) {
                _context.Temporal.Remove(temporal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TemporalExists}.
         *
         */
        private bool TemporalExists(int? id) {
            return _context.Temporal.Any(e => e.IntIdTemporal == id);
        }
    }
}
