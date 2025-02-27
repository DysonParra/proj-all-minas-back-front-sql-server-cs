/*
 * @fileoverview    {GeneradorPartidaController}
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
     * TODO: Description of {@code GeneradorPartidaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class GeneradorPartidaController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code GeneradorPartidaController}.
         *
         */
        public GeneradorPartidaController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: GeneradorPartida
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.GeneradorPartida.ToListAsync());
        }

        /**
         * GET: GeneradorPartida/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.GeneradorPartida == null) {
                return NotFound();
            }

            var generadorPartida = await _context.GeneradorPartida
                .FirstOrDefaultAsync(m => m.IntConsecutivo == id);
            if (generadorPartida == null) {
                return NotFound();
            }

            return View(generadorPartida);
        }

        /**
         * GET: GeneradorPartida/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: GeneradorPartida/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntConsecutivo,IntCodigoPartida,IntCodigoVehiculo,IntPeso,DtFecha,StrEstado,IntPesoEstimado,StrTipo,StrCifProveedor,StrRfid")] GeneradorPartida generadorPartida) {
            if (ModelState.IsValid) {
                _context.Add(generadorPartida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generadorPartida);
        }

        /**
         * GET: GeneradorPartida/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.GeneradorPartida == null) {
                return NotFound();
            }

            var generadorPartida = await _context.GeneradorPartida.FindAsync(id);
            if (generadorPartida == null) {
                return NotFound();
            }
            return View(generadorPartida);
        }

        /**
         * POST: GeneradorPartida/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntConsecutivo,IntCodigoPartida,IntCodigoVehiculo,IntPeso,DtFecha,StrEstado,IntPesoEstimado,StrTipo,StrCifProveedor,StrRfid")] GeneradorPartida generadorPartida) {
            if (id != generadorPartida.IntConsecutivo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(generadorPartida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!GeneradorPartidaExists(generadorPartida.IntConsecutivo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(generadorPartida);
        }

        /**
         * GET: GeneradorPartida/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.GeneradorPartida == null) {
                return NotFound();
            }

            var generadorPartida = await _context.GeneradorPartida
                .FirstOrDefaultAsync(m => m.IntConsecutivo == id);
            if (generadorPartida == null) {
                return NotFound();
            }

            return View(generadorPartida);
        }

        /**
         * POST: GeneradorPartida/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.GeneradorPartida == null) {
                return Problem("Entity set 'MinasContext.GeneradorPartida'  is null.");
            }
            var generadorPartida = await _context.GeneradorPartida.FindAsync(id);
            if (generadorPartida != null) {
                _context.GeneradorPartida.Remove(generadorPartida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code GeneradorPartidaExists}.
         *
         */
        private bool GeneradorPartidaExists(int? id) {
            return _context.GeneradorPartida.Any(e => e.IntConsecutivo == id);
        }
    }
}
