/*
 * @fileoverview    {ParqueController}
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
     * TODO: Description of {@code ParqueController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ParqueController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code ParqueController}.
         *
         */
        public ParqueController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Parque
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Parque.ToListAsync());
        }

        /**
         * GET: Parque/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Parque == null) {
                return NotFound();
            }

            var parque = await _context.Parque
                .FirstOrDefaultAsync(m => m.IntIdParque == id);
            if (parque == null) {
                return NotFound();
            }

            return View(parque);
        }

        /**
         * GET: Parque/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Parque/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdParque,StrNombreParque,StrObservaciones,StrUbicacion")] Parque parque) {
            if (ModelState.IsValid) {
                _context.Add(parque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parque);
        }

        /**
         * GET: Parque/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Parque == null) {
                return NotFound();
            }

            var parque = await _context.Parque.FindAsync(id);
            if (parque == null) {
                return NotFound();
            }
            return View(parque);
        }

        /**
         * POST: Parque/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdParque,StrNombreParque,StrObservaciones,StrUbicacion")] Parque parque) {
            if (id != parque.IntIdParque) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(parque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ParqueExists(parque.IntIdParque)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parque);
        }

        /**
         * GET: Parque/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Parque == null) {
                return NotFound();
            }

            var parque = await _context.Parque
                .FirstOrDefaultAsync(m => m.IntIdParque == id);
            if (parque == null) {
                return NotFound();
            }

            return View(parque);
        }

        /**
         * POST: Parque/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Parque == null) {
                return Problem("Entity set 'MinasContext.Parque'  is null.");
            }
            var parque = await _context.Parque.FindAsync(id);
            if (parque != null) {
                _context.Parque.Remove(parque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ParqueExists}.
         *
         */
        private bool ParqueExists(int? id) {
            return _context.Parque.Any(e => e.IntIdParque == id);
        }
    }
}
