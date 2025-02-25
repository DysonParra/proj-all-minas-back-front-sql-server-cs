/*
 * @fileoverview    {ControlAccesoController}
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
     * TODO: Description of {@code ControlAccesoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ControlAccesoController : Controller {
        private readonly MinasContext _context;

        public ControlAccesoController(MinasContext context) {
            _context = context;
        }

        // GET: ControlAcceso
        public async Task<IActionResult> Index() {
            return View(await _context.ControlAcceso.ToListAsync());
        }

        // GET: ControlAcceso/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.ControlAcceso == null) {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso
                .FirstOrDefaultAsync(m => m.IntIdControl == id);
            if (controlAcceso == null) {
                return NotFound();
            }

            return View(controlAcceso);
        }

        // GET: ControlAcceso/Create
        public IActionResult Create() {
            return View();
        }

        // POST: ControlAcceso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdControl,StrIdDestino,StrPlaca,StrConductor,DtFechaIngreso,DtFechaSalida,IntTopeMensual,IntAcumulado,DtFechaValidez,StrTipoTarjeta,IntIdContrato,StrIdMina,StrCifProveedor,StrRfid")] ControlAcceso controlAcceso) {
            if (ModelState.IsValid) {
                _context.Add(controlAcceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlAcceso);
        }

        // GET: ControlAcceso/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.ControlAcceso == null) {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso.FindAsync(id);
            if (controlAcceso == null) {
                return NotFound();
            }
            return View(controlAcceso);
        }

        // POST: ControlAcceso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdControl,StrIdDestino,StrPlaca,StrConductor,DtFechaIngreso,DtFechaSalida,IntTopeMensual,IntAcumulado,DtFechaValidez,StrTipoTarjeta,IntIdContrato,StrIdMina,StrCifProveedor,StrRfid")] ControlAcceso controlAcceso) {
            if (id != controlAcceso.IntIdControl) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(controlAcceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ControlAccesoExists(controlAcceso.IntIdControl)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(controlAcceso);
        }

        // GET: ControlAcceso/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.ControlAcceso == null) {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso
                .FirstOrDefaultAsync(m => m.IntIdControl == id);
            if (controlAcceso == null) {
                return NotFound();
            }

            return View(controlAcceso);
        }

        // POST: ControlAcceso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.ControlAcceso == null) {
                return Problem("Entity set 'MinasContext.ControlAcceso'  is null.");
            }
            var controlAcceso = await _context.ControlAcceso.FindAsync(id);
            if (controlAcceso != null) {
                _context.ControlAcceso.Remove(controlAcceso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlAccesoExists(int? id) {
            return _context.ControlAcceso.Any(e => e.IntIdControl == id);
        }
    }
}
