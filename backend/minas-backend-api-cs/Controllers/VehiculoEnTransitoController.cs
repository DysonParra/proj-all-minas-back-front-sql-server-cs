/*
 * @fileoverview    {VehiculoEnTransitoController}
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

namespace Minas.Controllers
{
    public class VehiculoEnTransitoController : Controller
    {
        private readonly MinasContext _context;

        public VehiculoEnTransitoController(MinasContext context)
        {
            _context = context;
        }

        // GET: VehiculoEnTransito
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculoEnTransito.ToListAsync());
        }

        // GET: VehiculoEnTransito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehiculoEnTransito == null)
            {
                return NotFound();
            }

            var vehiculoEnTransito = await _context.VehiculoEnTransito
                .FirstOrDefaultAsync(m => m.IntIdEntrada == id);
            if (vehiculoEnTransito == null)
            {
                return NotFound();
            }

            return View(vehiculoEnTransito);
        }

        // GET: VehiculoEnTransito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoEnTransito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdEntrada,IntIdParque,StrTransporte,StrTicket,StrMatricula,StrVagon,DtFechaEntrada,DtFechaSalida,StrCombustible,StrTipoMovimiento,StrNombre,StrParvaAnterior,DtFechaFinParva,StrPatio,DtFechaInicioParva,StrMuestras,StrNroBolsa,StrCodigoPartida,StrConsecutivoVehiculo,IntPesoEntrada,IntPesoSalida,IntPesoNeto,StrUnidad,StrDescripcion,TxtRutaFotos,StrRfid,BitProcesoManual,StrUsuario,BitVehiculoDevuelto,StrCif,StrIdDestino,StrIdOrigen,StrEstado,IntIdPorDia")] VehiculoEnTransito vehiculoEnTransito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoEnTransito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoEnTransito);
        }

        // GET: VehiculoEnTransito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehiculoEnTransito == null)
            {
                return NotFound();
            }

            var vehiculoEnTransito = await _context.VehiculoEnTransito.FindAsync(id);
            if (vehiculoEnTransito == null)
            {
                return NotFound();
            }
            return View(vehiculoEnTransito);
        }

        // POST: VehiculoEnTransito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdEntrada,IntIdParque,StrTransporte,StrTicket,StrMatricula,StrVagon,DtFechaEntrada,DtFechaSalida,StrCombustible,StrTipoMovimiento,StrNombre,StrParvaAnterior,DtFechaFinParva,StrPatio,DtFechaInicioParva,StrMuestras,StrNroBolsa,StrCodigoPartida,StrConsecutivoVehiculo,IntPesoEntrada,IntPesoSalida,IntPesoNeto,StrUnidad,StrDescripcion,TxtRutaFotos,StrRfid,BitProcesoManual,StrUsuario,BitVehiculoDevuelto,StrCif,StrIdDestino,StrIdOrigen,StrEstado,IntIdPorDia")] VehiculoEnTransito vehiculoEnTransito)
        {
            if (id != vehiculoEnTransito.IntIdEntrada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoEnTransito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoEnTransitoExists(vehiculoEnTransito.IntIdEntrada))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoEnTransito);
        }

        // GET: VehiculoEnTransito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehiculoEnTransito == null)
            {
                return NotFound();
            }

            var vehiculoEnTransito = await _context.VehiculoEnTransito
                .FirstOrDefaultAsync(m => m.IntIdEntrada == id);
            if (vehiculoEnTransito == null)
            {
                return NotFound();
            }

            return View(vehiculoEnTransito);
        }

        // POST: VehiculoEnTransito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.VehiculoEnTransito == null)
            {
                return Problem("Entity set 'MinasContext.VehiculoEnTransito'  is null.");
            }
            var vehiculoEnTransito = await _context.VehiculoEnTransito.FindAsync(id);
            if (vehiculoEnTransito != null)
            {
                _context.VehiculoEnTransito.Remove(vehiculoEnTransito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoEnTransitoExists(int? id)
        {
            return _context.VehiculoEnTransito.Any(e => e.IntIdEntrada == id);
        }
    }
}
