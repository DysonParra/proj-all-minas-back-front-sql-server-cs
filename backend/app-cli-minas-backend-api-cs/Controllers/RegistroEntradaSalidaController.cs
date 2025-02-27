/*
 * @fileoverview    {RegistroEntradaSalidaController}
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
     * TODO: Description of {@code RegistroEntradaSalidaController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RegistroEntradaSalidaController : Controller {
        private readonly MinasContext _context;

        /**
         * TODO: Description of method {@code RegistroEntradaSalidaController}.
         *
         */
        public RegistroEntradaSalidaController(MinasContext context) {
            _context = context;
        }

        /**
         * GET: RegistroEntradaSalida
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.RegistroEntradaSalida.ToListAsync());
        }

        /**
         * GET: RegistroEntradaSalida/Details/5
         *
         */
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.RegistroEntradaSalida == null) {
                return NotFound();
            }

            var registroEntradaSalida = await _context.RegistroEntradaSalida
                .FirstOrDefaultAsync(m => m.IntIdEntrada == id);
            if (registroEntradaSalida == null) {
                return NotFound();
            }

            return View(registroEntradaSalida);
        }

        /**
         * GET: RegistroEntradaSalida/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: RegistroEntradaSalida/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdEntrada,StrTransporte,StrTicket,StrMatricula,StrVagon,DtFechaEntrada,DtFechaSalida,StrCombustible,StrTipoMovimiento,StrNombre,StrParvaAnterior,DtFechaFinParva,StrPatio,DtFechaInicioParva,StrMuestras,StrNroBolsa,StrCodigoPartida,StrConsecutivoVehiculo,IntPesoEntrada,IntPesoSalida,IntPesoNeto,StrUnidad,StrDescripcion,TxtRutaFotos,StrRfid,BitProcesoManual,StrUsuario,BitVehiculoDevuelto,StrCif,StrIdDestino,StrIdOrigen,StrEstado,IntIdPorDia,IntIdParque")] RegistroEntradaSalida registroEntradaSalida) {
            if (ModelState.IsValid) {
                _context.Add(registroEntradaSalida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroEntradaSalida);
        }

        /**
         * GET: RegistroEntradaSalida/Edit/5
         *
         */
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.RegistroEntradaSalida == null) {
                return NotFound();
            }

            var registroEntradaSalida = await _context.RegistroEntradaSalida.FindAsync(id);
            if (registroEntradaSalida == null) {
                return NotFound();
            }
            return View(registroEntradaSalida);
        }

        /**
         * POST: RegistroEntradaSalida/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdEntrada,StrTransporte,StrTicket,StrMatricula,StrVagon,DtFechaEntrada,DtFechaSalida,StrCombustible,StrTipoMovimiento,StrNombre,StrParvaAnterior,DtFechaFinParva,StrPatio,DtFechaInicioParva,StrMuestras,StrNroBolsa,StrCodigoPartida,StrConsecutivoVehiculo,IntPesoEntrada,IntPesoSalida,IntPesoNeto,StrUnidad,StrDescripcion,TxtRutaFotos,StrRfid,BitProcesoManual,StrUsuario,BitVehiculoDevuelto,StrCif,StrIdDestino,StrIdOrigen,StrEstado,IntIdPorDia,IntIdParque")] RegistroEntradaSalida registroEntradaSalida) {
            if (id != registroEntradaSalida.IntIdEntrada) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(registroEntradaSalida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RegistroEntradaSalidaExists(registroEntradaSalida.IntIdEntrada)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registroEntradaSalida);
        }

        /**
         * GET: RegistroEntradaSalida/Delete/5
         *
         */
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.RegistroEntradaSalida == null) {
                return NotFound();
            }

            var registroEntradaSalida = await _context.RegistroEntradaSalida
                .FirstOrDefaultAsync(m => m.IntIdEntrada == id);
            if (registroEntradaSalida == null) {
                return NotFound();
            }

            return View(registroEntradaSalida);
        }

        /**
         * POST: RegistroEntradaSalida/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id) {
            if (_context.RegistroEntradaSalida == null) {
                return Problem("Entity set 'MinasContext.RegistroEntradaSalida'  is null.");
            }
            var registroEntradaSalida = await _context.RegistroEntradaSalida.FindAsync(id);
            if (registroEntradaSalida != null) {
                _context.RegistroEntradaSalida.Remove(registroEntradaSalida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code RegistroEntradaSalidaExists}.
         *
         */
        private bool RegistroEntradaSalidaExists(int? id) {
            return _context.RegistroEntradaSalida.Any(e => e.IntIdEntrada == id);
        }
    }
}
