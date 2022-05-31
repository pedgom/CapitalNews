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
    public class FotografiasController : Controller
    {
        private readonly CapitalDb _context;
        private readonly IWebHostEnvironment _caminho;

        public FotografiasController(CapitalDb context, IWebHostEnvironment caminho)
        {
            _context = context;
            _caminho = caminho;
        }

        // GET: Fotografias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Fotografias.ToListAsync());
        }

        // GET: Fotografias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // GET: Fotografias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fotografias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFoto,Descritores")] Fotografias fotografia, IFormFile fotos)
        {
            if (fotos == null)
            {
                fotografia.NomeFoto = "noJornalista.jpg";
            }
            else
            {
                if (!(fotos.ContentType == "image/png" || fotos.ContentType == "image/jpeg"))
                {
                   
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                   
                    return View(fotografia);
                }
                else
                {
                   
                    Guid g = Guid.NewGuid();
                    string nomeFoto = g.ToString();
                    string extensaoFoto = Path.GetExtension(fotos.FileName).ToLower();
                    nomeFoto += extensaoFoto;
                    fotografia.NomeFoto = nomeFoto;
                }
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(fotografia);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados da Foto " + fotografia.Descritores);
                    return View(fotografia);
                }
                if (fotos != null)
                {
                    
                    string nomeLocalizacaoFicheiro = _caminho.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
               
                    if (!Directory.Exists(nomeLocalizacaoFicheiro))
                    {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
  
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, fotografia.NomeFoto);
                   
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                 
                    await fotos.CopyToAsync(stream);
                }

               
                return RedirectToAction(nameof(Index));
            }
            return View(fotografia);
        }

        // GET: Fotografias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var fotografia = await _context.Fotografias.FindAsync(id);
            if (fotografia == null)
            {
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetInt32("FotoID", fotografia.Id);
            return View(fotografia);
        }

        // POST: Fotografias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFoto,Descritores")] Fotografias fotografia, IFormFile fotos)
        {
            if (id != fotografia.Id)
            {
                return NotFound();
            }

            var idFotoNoticia = HttpContext.Session.GetInt32("FotoID");

            if (idFotoNoticia == null)
            {
                
                ModelState.AddModelError("", "Demorou demasiado tempo a executar a tarefa de edição");
                return View(fotografia);
            }

            if (idFotoNoticia != fotografia.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotografia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografiasExists(fotografia.Id))
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
            return View(fotografia);
        }

        // GET: Fotografias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fotografias == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // POST: Fotografias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var fotografia = await _context.Fotografias.FindAsync(id);
                _context.Fotografias.Remove(fotografia);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
               
            }


            return RedirectToAction(nameof(Index));
        }
        private bool FotografiasExists(int id)
        {
          return _context.Fotografias.Any(e => e.Id == id);
        }
    }
}
