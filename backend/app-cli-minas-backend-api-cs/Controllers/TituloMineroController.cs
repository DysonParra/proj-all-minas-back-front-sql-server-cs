/*
 * @overview        {TituloMineroController}
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
     * TODO: Description of {@code TituloMineroController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TituloMineroController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code TituloMineroController}.
         *
         */
        public TituloMineroController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: TituloMinero
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.TituloMinero.ToListAsync());
        }

        /**
         * GET: TituloMinero/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.TituloMinero == null) {
                return NotFound();
            }

            var tituloMinero = await _context.TituloMinero
                .FirstOrDefaultAsync(m => m.StrIdTitulo == id);
            if (tituloMinero == null) {
                return NotFound();
            }

            return View(tituloMinero);
        }

        /**
         * GET: TituloMinero/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: TituloMinero/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrIdTitulo,StrNombre,StrLocalidad,StrTelefono,StrObservaciones,StrCifProveedor")] TituloMinero tituloMinero) {
            if (ModelState.IsValid) {
                _context.Add(tituloMinero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tituloMinero);
        }

        /**
         * GET: TituloMinero/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.TituloMinero == null) {
                return NotFound();
            }

            var tituloMinero = await _context.TituloMinero.FindAsync(id);
            if (tituloMinero == null) {
                return NotFound();
            }
            return View(tituloMinero);
        }

        /**
         * POST: TituloMinero/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrIdTitulo,StrNombre,StrLocalidad,StrTelefono,StrObservaciones,StrCifProveedor")] TituloMinero tituloMinero) {
            if (id != tituloMinero.StrIdTitulo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(tituloMinero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!TituloMineroExists(tituloMinero.StrIdTitulo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tituloMinero);
        }

        /**
         * GET: TituloMinero/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.TituloMinero == null) {
                return NotFound();
            }

            var tituloMinero = await _context.TituloMinero
                .FirstOrDefaultAsync(m => m.StrIdTitulo == id);
            if (tituloMinero == null) {
                return NotFound();
            }

            return View(tituloMinero);
        }

        /**
         * POST: TituloMinero/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.TituloMinero == null) {
                return Problem("Entity set 'MinasContext.TituloMinero'  is null.");
            }
            var tituloMinero = await _context.TituloMinero.FindAsync(id);
            if (tituloMinero != null) {
                _context.TituloMinero.Remove(tituloMinero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code TituloMineroExists}.
         *
         */
        private bool TituloMineroExists(string id) {
            return _context.TituloMinero.Any(e => e.StrIdTitulo == id);
        }
    }
}
