﻿/*
 * @fileoverview    {VehiculoController}
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
     * TODO: Description of {@code VehiculoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class VehiculoController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code VehiculoController}.
         *
         */
        public VehiculoController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: Vehiculo
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Vehiculo.ToListAsync());
        }

        /**
         * GET: Vehiculo/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Vehiculo == null) {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.StrRfid == id);
            if (vehiculo == null) {
                return NotFound();
            }

            return View(vehiculo);
        }

        /**
         * GET: Vehiculo/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Vehiculo/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrRfid,StrPlaca,StrTransporte,DtRevisionTecnomecanica,StrSeguro,IntTara,IntCapacidad,StrCategoria,StrIdMina,StrPatio,StrTope,StrIdConductor,StrCif")] Vehiculo vehiculo) {
            if (ModelState.IsValid) {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        /**
         * GET: Vehiculo/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Vehiculo == null) {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null) {
                return NotFound();
            }
            return View(vehiculo);
        }

        /**
         * POST: Vehiculo/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrRfid,StrPlaca,StrTransporte,DtRevisionTecnomecanica,StrSeguro,IntTara,IntCapacidad,StrCategoria,StrIdMina,StrPatio,StrTope,StrIdConductor,StrCif")] Vehiculo vehiculo) {
            if (id != vehiculo.StrRfid) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!VehiculoExists(vehiculo.StrRfid)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        /**
         * GET: Vehiculo/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Vehiculo == null) {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.StrRfid == id);
            if (vehiculo == null) {
                return NotFound();
            }

            return View(vehiculo);
        }

        /**
         * POST: Vehiculo/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Vehiculo == null) {
                return Problem("Entity set 'MinasContext.Vehiculo'  is null.");
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo != null) {
                _context.Vehiculo.Remove(vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code VehiculoExists}.
         *
         */
        private bool VehiculoExists(string id) {
            return _context.Vehiculo.Any(e => e.StrRfid == id);
        }
    }
}
