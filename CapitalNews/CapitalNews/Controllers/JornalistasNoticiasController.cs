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
    public class JornalistasNoticiasController : Controller
    {
        private readonly CapitalDb _context;

        public JornalistasNoticiasController(CapitalDb context)
        {
            _context = context;
        }

        // GET: JornalistasNoticias
        public async Task<IActionResult> Index()
        {
            var capitalDb = _context.JornalistasNoticias.Include(j => j.Jornalista).Include(j => j.Noticia);
            return View(await capitalDb.ToListAsync());
        }

        // GET: JornalistasNoticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JornalistasNoticias == null)
            {
                return NotFound();
            }

            var jornalistasNoticias = await _context.JornalistasNoticias
                .Include(j => j.Jornalista)
                .Include(j => j.Noticia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornalistasNoticias == null)
            {
                return NotFound();
            }

            return View(jornalistasNoticias);
        }

        // GET: JornalistasNoticias/Create
        public IActionResult Create()
        {
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas, "Id", "Id");
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id");
            return View();
        }

        // POST: JornalistasNoticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoticiaFK,JornalistaFK")] JornalistasNoticias jornalistasNoticias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornalistasNoticias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas, "Id", "Id", jornalistasNoticias.JornalistaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", jornalistasNoticias.NoticiaFK);
            return View(jornalistasNoticias);
        }

        // GET: JornalistasNoticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JornalistasNoticias == null)
            {
                return NotFound();
            }

            var jornalistasNoticias = await _context.JornalistasNoticias.FindAsync(id);
            if (jornalistasNoticias == null)
            {
                return NotFound();
            }
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas, "Id", "Id", jornalistasNoticias.JornalistaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", jornalistasNoticias.NoticiaFK);
            return View(jornalistasNoticias);
        }

        // POST: JornalistasNoticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoticiaFK,JornalistaFK")] JornalistasNoticias jornalistasNoticias)
        {
            if (id != jornalistasNoticias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornalistasNoticias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornalistasNoticiasExists(jornalistasNoticias.Id))
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
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas, "Id", "Id", jornalistasNoticias.JornalistaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", jornalistasNoticias.NoticiaFK);
            return View(jornalistasNoticias);
        }

        // GET: JornalistasNoticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JornalistasNoticias == null)
            {
                return NotFound();
            }

            var jornalistasNoticias = await _context.JornalistasNoticias
                .Include(j => j.Jornalista)
                .Include(j => j.Noticia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornalistasNoticias == null)
            {
                return NotFound();
            }

            return View(jornalistasNoticias);
        }

        // POST: JornalistasNoticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JornalistasNoticias == null)
            {
                return Problem("Entity set 'CapitalDb.JornalistasNoticias'  is null.");
            }
            var jornalistasNoticias = await _context.JornalistasNoticias.FindAsync(id);
            if (jornalistasNoticias != null)
            {
                _context.JornalistasNoticias.Remove(jornalistasNoticias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornalistasNoticiasExists(int id)
        {
          return _context.JornalistasNoticias.Any(e => e.Id == id);
        }
    }
}
