﻿/*
 * @fileoverview    {ConfiguracionController}
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
     * TODO: Description of {@code ConfiguracionController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ConfiguracionController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code ConfiguracionController}.
         *
         */
        public ConfiguracionController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Configuracion
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Configuracion.ToListAsync());
        }

        /**
         * GET: Configuracion/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Configuracion == null) {
                return NotFound();
            }

            var configuracion = await _context.Configuracion
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (configuracion == null) {
                return NotFound();
            }

            return View(configuracion);
        }

        /**
         * GET: Configuracion/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Configuracion/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,StrTipo,StrIndicador,StrBaudios,StrBitsDatos,StrBitsParada,StrParidad,StrIp,StrPuerto,StrUsuario,StrContrasena,BitEstado")] Configuracion configuracion) {
            if (ModelState.IsValid) {
                _context.Add(configuracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuracion);
        }

        /**
         * GET: Configuracion/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Configuracion == null) {
                return NotFound();
            }

            var configuracion = await _context.Configuracion.FindAsync(id);
            if (configuracion == null) {
                return NotFound();
            }
            return View(configuracion);
        }

        /**
         * POST: Configuracion/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntId,StrTipo,StrIndicador,StrBaudios,StrBitsDatos,StrBitsParada,StrParidad,StrIp,StrPuerto,StrUsuario,StrContrasena,BitEstado")] Configuracion configuracion) {
            if (id != configuracion.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(configuracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ConfiguracionExists(configuracion.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(configuracion);
        }

        /**
         * GET: Configuracion/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Configuracion == null) {
                return NotFound();
            }

            var configuracion = await _context.Configuracion
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (configuracion == null) {
                return NotFound();
            }

            return View(configuracion);
        }

        /**
         * POST: Configuracion/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.Configuracion == null) {
                return Problem("Entity set 'MinasContext.Configuracion'  is null.");
            }
            var configuracion = await _context.Configuracion.FindAsync(id);
            if (configuracion != null) {
                _context.Configuracion.Remove(configuracion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ConfiguracionExists}.
         *
         */
        private bool ConfiguracionExists(int? id) {
            return _context.Configuracion.Any(e => e.IntId == id);
        }
    }
}
