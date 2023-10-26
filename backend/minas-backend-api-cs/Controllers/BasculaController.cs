/*
 * @fileoverview    {BasculaController}
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
    public class BasculaController : Controller
    {
        private readonly MinasContext _context;

        public BasculaController(MinasContext context)
        {
            _context = context;
        }

        // GET: Bascula
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bascula.ToListAsync());
        }

        // GET: Bascula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bascula == null)
            {
                return NotFound();
            }

            var bascula = await _context.Bascula
                .FirstOrDefaultAsync(m => m.IntIdProveedor == id);
            if (bascula == null)
            {
                return NotFound();
            }

            return View(bascula);
        }

        // GET: Bascula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bascula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdProveedor,StrRfid,IntCodigoPartida,IntNumeroMuestra,IntEstadoPartida,DtFechaHoraEntrada,FltPesoBruto,FltPesoNeto,StrTipoVehiculo,StrMssCodigoPartida,DtMssFechaHoraTomaMuestra")] Bascula bascula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bascula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bascula);
        }

        // GET: Bascula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bascula == null)
            {
                return NotFound();
            }

            var bascula = await _context.Bascula.FindAsync(id);
            if (bascula == null)
            {
                return NotFound();
            }
            return View(bascula);
        }

        // POST: Bascula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntIdProveedor,StrRfid,IntCodigoPartida,IntNumeroMuestra,IntEstadoPartida,DtFechaHoraEntrada,FltPesoBruto,FltPesoNeto,StrTipoVehiculo,StrMssCodigoPartida,DtMssFechaHoraTomaMuestra")] Bascula bascula)
        {
            if (id != bascula.IntIdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bascula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasculaExists(bascula.IntIdProveedor))
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
            return View(bascula);
        }

        // GET: Bascula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bascula == null)
            {
                return NotFound();
            }

            var bascula = await _context.Bascula
                .FirstOrDefaultAsync(m => m.IntIdProveedor == id);
            if (bascula == null)
            {
                return NotFound();
            }

            return View(bascula);
        }

        // POST: Bascula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Bascula == null)
            {
                return Problem("Entity set 'MinasContext.Bascula'  is null.");
            }
            var bascula = await _context.Bascula.FindAsync(id);
            if (bascula != null)
            {
                _context.Bascula.Remove(bascula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasculaExists(int? id)
        {
            return _context.Bascula.Any(e => e.IntIdProveedor == id);
        }
    }
}
