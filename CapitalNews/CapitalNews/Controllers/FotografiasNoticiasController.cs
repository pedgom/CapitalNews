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
    public class FotografiasNoticiasController : Controller
    {
        private readonly CapitalDb _context;

        public FotografiasNoticiasController(CapitalDb context)
        {
            _context = context;
        }

        // GET: FotografiasNoticias
        public async Task<IActionResult> Index()
        {
            var capitalDb = _context.FotografiasNoticias.Include(f => f.Fotografia).Include(f => f.Noticia);
            return View(await capitalDb.ToListAsync());
        }

        // GET: FotografiasNoticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FotografiasNoticias == null)
            {
                return NotFound();
            }

            var fotografiasNoticias = await _context.FotografiasNoticias
                .Include(f => f.Fotografia)
                .Include(f => f.Noticia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografiasNoticias == null)
            {
                return NotFound();
            }

            return View(fotografiasNoticias);
        }

        // GET: FotografiasNoticias/Create
        public IActionResult Create()
        {
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias, "Id", "Id");
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id");
            return View();
        }

        // POST: FotografiasNoticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FotografiaFK,NoticiaFK")] FotografiasNoticias fotografiasNoticias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotografiasNoticias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias, "Id", "Id", fotografiasNoticias.FotografiaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", fotografiasNoticias.NoticiaFK);
            return View(fotografiasNoticias);
        }

        // GET: FotografiasNoticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FotografiasNoticias == null)
            {
                return NotFound();
            }

            var fotografiasNoticias = await _context.FotografiasNoticias.FindAsync(id);
            if (fotografiasNoticias == null)
            {
                return NotFound();
            }
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias, "Id", "Id", fotografiasNoticias.FotografiaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", fotografiasNoticias.NoticiaFK);
            return View(fotografiasNoticias);
        }

        // POST: FotografiasNoticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FotografiaFK,NoticiaFK")] FotografiasNoticias fotografiasNoticias)
        {
            if (id != fotografiasNoticias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotografiasNoticias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografiasNoticiasExists(fotografiasNoticias.Id))
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
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias, "Id", "Id", fotografiasNoticias.FotografiaFK);
            ViewData["NoticiaFK"] = new SelectList(_context.Noticias, "Id", "Id", fotografiasNoticias.NoticiaFK);
            return View(fotografiasNoticias);
        }

        // GET: FotografiasNoticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FotografiasNoticias == null)
            {
                return NotFound();
            }

            var fotografiasNoticias = await _context.FotografiasNoticias
                .Include(f => f.Fotografia)
                .Include(f => f.Noticia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografiasNoticias == null)
            {
                return NotFound();
            }

            return View(fotografiasNoticias);
        }

        // POST: FotografiasNoticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FotografiasNoticias == null)
            {
                return Problem("Entity set 'CapitalDb.FotografiasNoticias'  is null.");
            }
            var fotografiasNoticias = await _context.FotografiasNoticias.FindAsync(id);
            if (fotografiasNoticias != null)
            {
                _context.FotografiasNoticias.Remove(fotografiasNoticias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografiasNoticiasExists(int id)
        {
          return _context.FotografiasNoticias.Any(e => e.Id == id);
        }
    }
}
