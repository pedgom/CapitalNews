using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalNews.Data;
using CapitalNews.Models;

namespace CapitalNews.Controllers
{
    public class JornalistasController : Controller
    {
        private readonly CapitalDb _context;

        public JornalistasController(CapitalDb context)
        {
            _context = context;
        }

        // GET: Jornalistas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jornalistas.ToListAsync());
        }

        // GET: Jornalistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jornalistas == null)
            {
                return NotFound();
            }

            var jornalistas = await _context.Jornalistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornalistas == null)
            {
                return NotFound();
            }

            return View(jornalistas);
        }

        // GET: Jornalistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jornalistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Fotojor")] Jornalistas jornalistas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornalistas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jornalistas);
        }

        // GET: Jornalistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jornalistas == null)
            {
                return NotFound();
            }

            var jornalistas = await _context.Jornalistas.FindAsync(id);
            if (jornalistas == null)
            {
                return NotFound();
            }
            return View(jornalistas);
        }

        // POST: Jornalistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Fotojor")] Jornalistas jornalistas)
        {
            if (id != jornalistas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornalistas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornalistasExists(jornalistas.Id))
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
            return View(jornalistas);
        }

        // GET: Jornalistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jornalistas == null)
            {
                return NotFound();
            }

            var jornalistas = await _context.Jornalistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornalistas == null)
            {
                return NotFound();
            }

            return View(jornalistas);
        }

        // POST: Jornalistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jornalistas == null)
            {
                return Problem("Entity set 'CapitalDb.Jornalistas'  is null.");
            }
            var jornalistas = await _context.Jornalistas.FindAsync(id);
            if (jornalistas != null)
            {
                _context.Jornalistas.Remove(jornalistas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornalistasExists(int id)
        {
          return _context.Jornalistas.Any(e => e.Id == id);
        }
    }
}
