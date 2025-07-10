/*
 * @overview        {ProductoController}
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
     * TODO: Description of {@code ProductoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ProductoController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code ProductoController}.
         *
         */
        public ProductoController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Producto
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Producto.ToListAsync());
        }

        /**
         * GET: Producto/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Producto == null) {
                return NotFound();
            }

            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.IntIdProducto == id);
            if (producto == null) {
                return NotFound();
            }

            return View(producto);
        }

        /**
         * GET: Producto/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Producto/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdProducto,StrProducto")] Producto producto) {
            if (ModelState.IsValid) {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        /**
         * GET: Producto/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Producto == null) {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) {
                return NotFound();
            }
            return View(producto);
        }

        /**
         * POST: Producto/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdProducto,StrProducto")] Producto producto) {
            if (id != producto.IntIdProducto) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ProductoExists(producto.IntIdProducto)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        /**
         * GET: Producto/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Producto == null) {
                return NotFound();
            }

            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.IntIdProducto == id);
            if (producto == null) {
                return NotFound();
            }

            return View(producto);
        }

        /**
         * POST: Producto/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Producto == null) {
                return Problem("Entity set 'MinasContext.Producto'  is null.");
            }
            var producto = await _context.Producto.FindAsync(id);
            if (producto != null) {
                _context.Producto.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ProductoExists}.
         *
         */
        private bool ProductoExists(int? id) {
            return _context.Producto.Any(e => e.IntIdProducto == id);
        }
    }
}
