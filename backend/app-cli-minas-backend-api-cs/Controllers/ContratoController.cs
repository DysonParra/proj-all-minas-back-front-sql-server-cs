/*
 * @overview        {ContratoController}
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
     * TODO: Description of {@code ContratoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ContratoController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code ContratoController}.
         *
         */
        public ContratoController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Contrato
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Contrato.ToListAsync());
        }

        /**
         * GET: Contrato/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Contrato == null) {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.IntIdContrato == id);
            if (contrato == null) {
                return NotFound();
            }

            return View(contrato);
        }

        /**
         * GET: Contrato/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Contrato/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdContrato,StrIdParque,StrCentroProduccion,StrCarburante,StrTipoAgrupacion,BitPartidaMaestra,IntTipoExistencia,StrDescripcion")] Contrato contrato) {
            if (ModelState.IsValid) {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        /**
         * GET: Contrato/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Contrato == null) {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null) {
                return NotFound();
            }
            return View(contrato);
        }

        /**
         * POST: Contrato/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdContrato,StrIdParque,StrCentroProduccion,StrCarburante,StrTipoAgrupacion,BitPartidaMaestra,IntTipoExistencia,StrDescripcion")] Contrato contrato) {
            if (id != contrato.IntIdContrato) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ContratoExists(contrato.IntIdContrato)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        /**
         * GET: Contrato/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Contrato == null) {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.IntIdContrato == id);
            if (contrato == null) {
                return NotFound();
            }

            return View(contrato);
        }

        /**
         * POST: Contrato/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Contrato == null) {
                return Problem("Entity set 'MinasContext.Contrato'  is null.");
            }
            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato != null) {
                _context.Contrato.Remove(contrato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ContratoExists}.
         *
         */
        private bool ContratoExists(int? id) {
            return _context.Contrato.Any(e => e.IntIdContrato == id);
        }
    }
}
