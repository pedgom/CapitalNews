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
    public class NoticiasController : Controller
    {
        private readonly CapitalDb _context;

        public NoticiasController(CapitalDb context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            var capitalDb = _context.Noticias.Include(n => n.Categoria).Include(n => n.Fotografia).Include(n => n.Jornalista);
            return View(await capitalDb.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Noticias == null)
            {
                return NotFound();
            }



            
            var noticias = await _context.Noticias
                .Include(n => n.Categoria)
                .Include(n => n.Fotografia)
                .Include(n => n.Jornalista)
                .Include(r => r.ListaComentarios).Where(c => c.Id == id)

                .FirstOrDefaultAsync(m => m.Id == id);

           


            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {

            

            ViewData["CategoriaFK"] = new SelectList(_context.Categorias.OrderBy(c => c.CategoriaNome), "Id", "CategoriaNome");
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias.OrderBy(f => f.Descritores), "Id", "Descritores");
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas.OrderBy(j => j.Nome), "Id", "Nome");
            
            
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Body,Data,CategoriaFK,JornalistaFK,FotografiaFK")] Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                noticias.Data= DateTime.Now;
                _context.Add(noticias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias.OrderBy(c => c.CategoriaNome), "Id", "CategoriaNome", noticias.CategoriaFK);
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias.OrderBy(f => f.Descritores), "Id", "Descritores", noticias.FotografiaFK);
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas.OrderBy(j => j.Nome), "Id", "Nome", noticias.JornalistaFK);
            return View(noticias);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Noticias == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias.OrderBy(c => c.CategoriaNome), "Id", "CategoriaNome", noticias.CategoriaFK);
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias.OrderBy(f => f.Descritores), "Id", "Descritores", noticias.FotografiaFK);
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas.OrderBy(j => j.Nome), "Id", "Nome", noticias.JornalistaFK);
            return View(noticias);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Body,Data,CategoriaFK,JornalistaFK,FotografiaFK")] Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiasExists(noticias.Id))
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
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "CategoriaNome", noticias.CategoriaFK);
            ViewData["FotografiaFK"] = new SelectList(_context.Fotografias, "Id", "Descritor", noticias.FotografiaFK);
            ViewData["JornalistaFK"] = new SelectList(_context.Jornalistas, "Id", "Nome", noticias.JornalistaFK);
            return View(noticias);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Noticias == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias
                .Include(n => n.Categoria)
                .Include(n => n.Fotografia)
                .Include(n => n.Jornalista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Noticias == null)
            {
                return Problem("Entity set 'CapitalDb.Noticias'  is null.");
            }
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias != null)
            {
                _context.Noticias.Remove(noticias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiasExists(int id)
        {
          return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
