/*
 * @fileoverview    {FicherosProveedorController}
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
     * TODO: Description of {@code FicherosProveedorController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class FicherosProveedorController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code FicherosProveedorController}.
         *
         */
        public FicherosProveedorController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: FicherosProveedor
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.FicherosProveedor.ToListAsync());
        }

        /**
         * GET: FicherosProveedor/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.FicherosProveedor == null) {
                return NotFound();
            }

            var ficherosProveedor = await _context.FicherosProveedor
                .FirstOrDefaultAsync(m => m.StrCif == id);
            if (ficherosProveedor == null) {
                return NotFound();
            }

            return View(ficherosProveedor);
        }

        /**
         * GET: FicherosProveedor/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: FicherosProveedor/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrCif,StrNombre,IntTopeMensual,DtFechaHoraCarga,StrIdUsuario")] FicherosProveedor ficherosProveedor) {
            if (ModelState.IsValid) {
                _context.Add(ficherosProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ficherosProveedor);
        }

        /**
         * GET: FicherosProveedor/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.FicherosProveedor == null) {
                return NotFound();
            }

            var ficherosProveedor = await _context.FicherosProveedor.FindAsync(id);
            if (ficherosProveedor == null) {
                return NotFound();
            }
            return View(ficherosProveedor);
        }

        /**
         * POST: FicherosProveedor/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrCif,StrNombre,IntTopeMensual,DtFechaHoraCarga,StrIdUsuario")] FicherosProveedor ficherosProveedor) {
            if (id != ficherosProveedor.StrCif) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ficherosProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!FicherosProveedorExists(ficherosProveedor.StrCif)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ficherosProveedor);
        }

        /**
         * GET: FicherosProveedor/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.FicherosProveedor == null) {
                return NotFound();
            }

            var ficherosProveedor = await _context.FicherosProveedor
                .FirstOrDefaultAsync(m => m.StrCif == id);
            if (ficherosProveedor == null) {
                return NotFound();
            }

            return View(ficherosProveedor);
        }

        /**
         * POST: FicherosProveedor/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.FicherosProveedor == null) {
                return Problem("Entity set 'MinasContext.FicherosProveedor'  is null.");
            }
            var ficherosProveedor = await _context.FicherosProveedor.FindAsync(id);
            if (ficherosProveedor != null) {
                _context.FicherosProveedor.Remove(ficherosProveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code FicherosProveedorExists}.
         *
         */
        private bool FicherosProveedorExists(string id) {
            return _context.FicherosProveedor.Any(e => e.StrCif == id);
        }
    }
}
