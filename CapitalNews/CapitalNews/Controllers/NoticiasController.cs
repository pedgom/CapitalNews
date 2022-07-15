using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalNews.Data;
using CapitalNews.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CapitalNews.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly CapitalDb _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _caminho;

        public NoticiasController(CapitalDb context, UserManager<ApplicationUser> userManager, IWebHostEnvironment caminho)
        {
            _context = context;
            _userManager = userManager;
            _caminho = caminho;
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
                .Include(r => r.ListaComentarios)
                .ThenInclude(r => r.Leitor)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        public async Task<IActionResult> Comentar(int id, string comentario)
        {
            Comentarios comentarios = new Comentarios
            {
                TextoComentario = comentario,
                DataComentario = DateTime.Now,
                Visibilidade = true,
                NoticiaFK = id,
            };
            var user_id = _userManager.GetUserId(User);
            var leitor = _context.Leitores.FirstOrDefault(x => x.UserID == user_id);
            comentarios.LeitorFK = leitor.Id;
            comentarios.Leitor = leitor;
            var noticia = _context.Noticias.FirstOrDefault(x => x.Id == id);
            comentarios.Noticia = noticia;
            _context.Add(comentarios);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Noticias", new { id = comentarios.NoticiaFK});
        }


        [Authorize]
        [Authorize(Roles="Jornalista")]
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
        [Authorize]
        [Authorize(Roles = "Jornalista")]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Body,Data,CategoriaFK,JornalistaFK,FotografiaFK")] Noticias noticias, IFormFile fotos)
        {

            Fotografias fotografia = new Fotografias();

            if (fotos == null)
            {
                fotografia.NomeFoto = "noJornalista.jpg";
            }
            else
            {
                if (!(fotos.ContentType == "image/png" || fotos.ContentType == "image/jpeg"))
                {

                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");

                    return View(noticias);
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

            try
            {
                _context.Add(fotografia);
                await _context.SaveChangesAsync();
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
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados da Foto " + fotografia.Descritores);
                return View(noticias);
            }


            var user_id = _userManager.GetUserId(User);
            var leitor = _context.Leitores.FirstOrDefault(x => x.UserID == user_id);
            noticias.JornalistaFK = 1;
            noticias.FotografiaFK = fotografia.Id;
            noticias.Fotografia = fotografia;
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
        [Authorize]
        [Authorize(Roles = "Jornalista")]
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
        [Authorize]
        [Authorize(Roles = "Jornalista")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Body,Data,CategoriaFK,JornalistaFK,FotografiaFK")] Noticias noticias, IFormFile fotos)
        {

            if (id != noticias.Id)
            {
                return NotFound();
            }

            Fotografias fotografia = new Fotografias();

            if (fotos == null)
            {
                fotografia.NomeFoto = "noJornalista.jpg";
            }
            else
            {
                if (!(fotos.ContentType == "image/png" || fotos.ContentType == "image/jpeg"))
                {

                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");

                    return View(noticias);
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

            try
            {
                _context.Add(fotografia);
                await _context.SaveChangesAsync();
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
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados da Foto " + fotografia.Descritores);
                return View(noticias);
            }

            noticias.FotografiaFK = fotografia.Id;
            noticias.Fotografia = fotografia;
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
        [Authorize]
        [Authorize(Roles = "Jornalista")]
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
        [Authorize]
        [Authorize(Roles = "Jornalista")]
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
