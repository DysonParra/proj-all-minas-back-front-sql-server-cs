/*
 * @fileoverview    {CodigoOrigenController}
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
    public class CodigoOrigenController : Controller
    {
        private readonly MinasContext _context;

        public CodigoOrigenController(MinasContext context)
        {
            _context = context;
        }

        // GET: CodigoOrigen
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodigoOrigen.ToListAsync());
        }

        // GET: CodigoOrigen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CodigoOrigen == null)
            {
                return NotFound();
            }

            var codigoOrigen = await _context.CodigoOrigen
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (codigoOrigen == null)
            {
                return NotFound();
            }

            return View(codigoOrigen);
        }

        // GET: CodigoOrigen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodigoOrigen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,StrCodigo")] CodigoOrigen codigoOrigen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigoOrigen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigoOrigen);
        }

        // GET: CodigoOrigen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CodigoOrigen == null)
            {
                return NotFound();
            }

            var codigoOrigen = await _context.CodigoOrigen.FindAsync(id);
            if (codigoOrigen == null)
            {
                return NotFound();
            }
            return View(codigoOrigen);
        }

        // POST: CodigoOrigen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IntId,StrCodigo")] CodigoOrigen codigoOrigen)
        {
            if (id != codigoOrigen.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigoOrigen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoOrigenExists(codigoOrigen.IntId))
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
            return View(codigoOrigen);
        }

        // GET: CodigoOrigen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CodigoOrigen == null)
            {
                return NotFound();
            }

            var codigoOrigen = await _context.CodigoOrigen
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (codigoOrigen == null)
            {
                return NotFound();
            }

            return View(codigoOrigen);
        }

        // POST: CodigoOrigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.CodigoOrigen == null)
            {
                return Problem("Entity set 'MinasContext.CodigoOrigen'  is null.");
            }
            var codigoOrigen = await _context.CodigoOrigen.FindAsync(id);
            if (codigoOrigen != null)
            {
                _context.CodigoOrigen.Remove(codigoOrigen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodigoOrigenExists(int? id)
        {
            return _context.CodigoOrigen.Any(e => e.IntId == id);
        }
    }
}
