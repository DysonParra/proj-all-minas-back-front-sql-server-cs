/*
 * @fileoverview    {CierrePartidaController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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
    public class CierrePartidaController : Controller
    {
        private readonly MinasContext _context;

        public CierrePartidaController(MinasContext context)
        {
            _context = context;
        }

        // GET: CierrePartida
        public async Task<IActionResult> Index()
        {
            return View(await _context.CierrePartida.ToListAsync());
        }

        // GET: CierrePartida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CierrePartida == null)
            {
                return NotFound();
            }

            var cierrePartida = await _context.CierrePartida
                .FirstOrDefaultAsync(m => m.IntConsecutivo == id);
            if (cierrePartida == null)
            {
                return NotFound();
            }

            return View(cierrePartida);
        }

        // GET: CierrePartida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CierrePartida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntConsecutivo,IntCodigoPartida,StrCifProveedor,IntCodigoVehiculo,StrRfid,IntPeso,DtFecha,StrEstado,IntPesoEstimado,StrTipo")] CierrePartida cierrePartida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cierrePartida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cierrePartida);
        }

        // GET: CierrePartida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CierrePartida == null)
            {
                return NotFound();
            }

            var cierrePartida = await _context.CierrePartida.FindAsync(id);
            if (cierrePartida == null)
            {
                return NotFound();
            }
            return View(cierrePartida);
        }

        // POST: CierrePartida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntConsecutivo,IntCodigoPartida,StrCifProveedor,IntCodigoVehiculo,StrRfid,IntPeso,DtFecha,StrEstado,IntPesoEstimado,StrTipo")] CierrePartida cierrePartida)
        {
            if (id != cierrePartida.IntConsecutivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cierrePartida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CierrePartidaExists(cierrePartida.IntConsecutivo))
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
            return View(cierrePartida);
        }

        // GET: CierrePartida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CierrePartida == null)
            {
                return NotFound();
            }

            var cierrePartida = await _context.CierrePartida
                .FirstOrDefaultAsync(m => m.IntConsecutivo == id);
            if (cierrePartida == null)
            {
                return NotFound();
            }

            return View(cierrePartida);
        }

        // POST: CierrePartida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.CierrePartida == null)
            {
                return Problem("Entity set 'MinasContext.CierrePartida'  is null.");
            }
            var cierrePartida = await _context.CierrePartida.FindAsync(id);
            if (cierrePartida != null)
            {
                _context.CierrePartida.Remove(cierrePartida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CierrePartidaExists(int? id)
        {
            return _context.CierrePartida.Any(e => e.IntConsecutivo == id);
        }
    }
}
