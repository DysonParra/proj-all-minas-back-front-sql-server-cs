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
    public class ConsecutivoDiarioController : Controller
    {
        private readonly MinasContext _context;

        public ConsecutivoDiarioController(MinasContext context)
        {
            _context = context;
        }

        // GET: ConsecutivoDiario
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsecutivoDiario.ToListAsync());
        }

        // GET: ConsecutivoDiario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ConsecutivoDiario == null)
            {
                return NotFound();
            }

            var consecutivoDiario = await _context.ConsecutivoDiario
                .FirstOrDefaultAsync(m => m.StrRfid == id);
            if (consecutivoDiario == null)
            {
                return NotFound();
            }

            return View(consecutivoDiario);
        }

        // GET: ConsecutivoDiario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsecutivoDiario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrRfid,IntNroTiquete,IntConsecutivoDia")] ConsecutivoDiario consecutivoDiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consecutivoDiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consecutivoDiario);
        }

        // GET: ConsecutivoDiario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ConsecutivoDiario == null)
            {
                return NotFound();
            }

            var consecutivoDiario = await _context.ConsecutivoDiario.FindAsync(id);
            if (consecutivoDiario == null)
            {
                return NotFound();
            }
            return View(consecutivoDiario);
        }

        // POST: ConsecutivoDiario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrRfid,IntNroTiquete,IntConsecutivoDia")] ConsecutivoDiario consecutivoDiario)
        {
            if (id != consecutivoDiario.StrRfid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consecutivoDiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsecutivoDiarioExists(consecutivoDiario.StrRfid))
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
            return View(consecutivoDiario);
        }

        // GET: ConsecutivoDiario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ConsecutivoDiario == null)
            {
                return NotFound();
            }

            var consecutivoDiario = await _context.ConsecutivoDiario
                .FirstOrDefaultAsync(m => m.StrRfid == id);
            if (consecutivoDiario == null)
            {
                return NotFound();
            }

            return View(consecutivoDiario);
        }

        // POST: ConsecutivoDiario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ConsecutivoDiario == null)
            {
                return Problem("Entity set 'MinasContext.ConsecutivoDiario'  is null.");
            }
            var consecutivoDiario = await _context.ConsecutivoDiario.FindAsync(id);
            if (consecutivoDiario != null)
            {
                _context.ConsecutivoDiario.Remove(consecutivoDiario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsecutivoDiarioExists(string id)
        {
            return _context.ConsecutivoDiario.Any(e => e.StrRfid == id);
        }
    }
}
