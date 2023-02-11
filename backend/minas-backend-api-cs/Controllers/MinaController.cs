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
    public class MinaController : Controller
    {
        private readonly MinasContext _context;

        public MinaController(MinasContext context)
        {
            _context = context;
        }

        // GET: Mina
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mina.ToListAsync());
        }

        // GET: Mina/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Mina == null)
            {
                return NotFound();
            }

            var mina = await _context.Mina
                .FirstOrDefaultAsync(m => m.StrIdMina == id);
            if (mina == null)
            {
                return NotFound();
            }

            return View(mina);
        }

        // GET: Mina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrIdMina,StrNombre,StrLocalidad,StrTelefono,StrObservaciones,StrProducto,StrTicket,StrIdTituloMinero")] Mina mina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mina);
        }

        // GET: Mina/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Mina == null)
            {
                return NotFound();
            }

            var mina = await _context.Mina.FindAsync(id);
            if (mina == null)
            {
                return NotFound();
            }
            return View(mina);
        }

        // POST: Mina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrIdMina,StrNombre,StrLocalidad,StrTelefono,StrObservaciones,StrProducto,StrTicket,StrIdTituloMinero")] Mina mina)
        {
            if (id != mina.StrIdMina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinaExists(mina.StrIdMina))
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
            return View(mina);
        }

        // GET: Mina/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Mina == null)
            {
                return NotFound();
            }

            var mina = await _context.Mina
                .FirstOrDefaultAsync(m => m.StrIdMina == id);
            if (mina == null)
            {
                return NotFound();
            }

            return View(mina);
        }

        // POST: Mina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Mina == null)
            {
                return Problem("Entity set 'MinasContext.Mina'  is null.");
            }
            var mina = await _context.Mina.FindAsync(id);
            if (mina != null)
            {
                _context.Mina.Remove(mina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinaExists(string id)
        {
            return _context.Mina.Any(e => e.StrIdMina == id);
        }
    }
}
