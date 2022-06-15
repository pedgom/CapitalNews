using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalNews.Data;
using CapitalNews.Models;

namespace CapitalNews.Controllers
{
    [Authorize]
    public class LeitoresController : Controller
    {
        private readonly CapitalDb _context;

        public LeitoresController(CapitalDb context)
        {
            _context = context;
        }

        // GET: Leitores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Leitores.ToListAsync());
        }

        // GET: Leitores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leitores == null)
            {
                return NotFound();
            }

            var leitores = await _context.Leitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leitores == null)
            {
                return NotFound();
            }

            return View(leitores);
        }

        // GET: Leitores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leitores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Datanasc,Sexo,Fotolei,Username")] Leitores leitores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leitores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leitores);
        }

        // GET: Leitores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leitores == null)
            {
                return NotFound();
            }

            var leitores = await _context.Leitores.FindAsync(id);
            if (leitores == null)
            {
                return NotFound();
            }
            return View(leitores);
        }

        // POST: Leitores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Datanasc,Sexo,Fotolei,Username")] Leitores leitores)
        {
            if (id != leitores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leitores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeitoresExists(leitores.Id))
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
            return View(leitores);
        }

        // GET: Leitores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leitores == null)
            {
                return NotFound();
            }

            var leitores = await _context.Leitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leitores == null)
            {
                return NotFound();
            }

            return View(leitores);
        }

        // POST: Leitores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leitores == null)
            {
                return Problem("Entity set 'CapitalDb.Leitores'  is null.");
            }
            var leitores = await _context.Leitores.FindAsync(id);
            if (leitores != null)
            {
                _context.Leitores.Remove(leitores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeitoresExists(int id)
        {
          return _context.Leitores.Any(e => e.Id == id);
        }
    }
}
