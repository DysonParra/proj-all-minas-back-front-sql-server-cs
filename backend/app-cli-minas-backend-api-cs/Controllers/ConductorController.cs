﻿/*
 * @overview        {ConductorController}
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
     * TODO: Description of {@code ConductorController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ConductorController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code ConductorController}.
         *
         */
        public ConductorController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Conductor
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Conductor.ToListAsync());
        }

        /**
         * GET: Conductor/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Conductor == null) {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.StrIdentificacion == id);
            if (conductor == null) {
                return NotFound();
            }

            return View(conductor);
        }

        /**
         * GET: Conductor/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Conductor/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrIdentificacion,StrNombreConductor,DtFechaNacimiento,StrLicenciaConduccion,DtFechaVencimiento,StrObservaciones,StrTipoSancion,DtFechaInicioSancion,DtFechaFinalSancion,StrDiasSancion")] Conductor conductor) {
            if (ModelState.IsValid) {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        /**
         * GET: Conductor/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Conductor == null) {
                return NotFound();
            }

            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor == null) {
                return NotFound();
            }
            return View(conductor);
        }

        /**
         * POST: Conductor/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrIdentificacion,StrNombreConductor,DtFechaNacimiento,StrLicenciaConduccion,DtFechaVencimiento,StrObservaciones,StrTipoSancion,DtFechaInicioSancion,DtFechaFinalSancion,StrDiasSancion")] Conductor conductor) {
            if (id != conductor.StrIdentificacion) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ConductorExists(conductor.StrIdentificacion)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        /**
         * GET: Conductor/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Conductor == null) {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.StrIdentificacion == id);
            if (conductor == null) {
                return NotFound();
            }

            return View(conductor);
        }

        /**
         * POST: Conductor/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Conductor == null) {
                return Problem("Entity set 'MinasContext.Conductor'  is null.");
            }
            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor != null) {
                _context.Conductor.Remove(conductor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code ConductorExists}.
         *
         */
        private bool ConductorExists(string id) {
            return _context.Conductor.Any(e => e.StrIdentificacion == id);
        }
    }
}
