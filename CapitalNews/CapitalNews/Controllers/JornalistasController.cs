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

        private readonly IWebHostEnvironment _webHostEnvironment;
        public JornalistasController(CapitalDb context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Jornalistas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jornalistas.ToListAsync());
        }

        // GET: Jornalistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Fotojor")] Jornalistas jornalista, IFormFile fotoJornalista)
        {
            if( fotoJornalista == null)
            {
                jornalista.Fotojor = "noJornalista.jpg";
            }
            else
            {
                if (!(fotoJornalista.ContentType == "image/png" || fotoJornalista.ContentType == "image/jpeg"))
                {
                    // criar mensagem de erro
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    // revolver o controlo da app à View
                    // fornecendo-lhe os dados que o utilizador já tinha preenchido no formulário
                    return View(jornalista);
                }
                else
                {
                    Guid g = Guid.NewGuid();
                    string nomeFoto = g.ToString();
                    string extensaoFoto = Path.GetExtension(fotoJornalista.FileName).ToLower();
                    nomeFoto += extensaoFoto;
                    // atribuir ao vet o nome da sua foto
                    jornalista.Fotojor = nomeFoto;
                }
            }


            if (ModelState.IsValid)
            {
                try { 
                    _context.Add(jornalista);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados do jornalista " + jornalista.Nome);
                    // devolver controlo à View
                    return View(jornalista);
                }

                if (fotoJornalista != null)
                {
                    // onde o ficheiro vai ser guardado?
                    string nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                    // avaliar se a pasta 'Fotos' não existe
                    if (!Directory.Exists(nomeLocalizacaoFicheiro))
                    {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
                    // nome do documento a guardar
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, jornalista.Fotojor);
                    // criar o objeto que vai manipular o ficheiro
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    // guardar no disco rígido
                    await fotoJornalista.CopyToAsync(stream);
                }
                return RedirectToAction(nameof(Index));

            }

            return View(jornalista);
        }

        // GET: Jornalistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return RedirectToAction("Index");
            }

            var jornalista = await _context.Jornalistas.FindAsync(id);
            if (jornalista == null)
            {
                return RedirectToAction("Index");

            }

            HttpContext.Session.SetInt32("JornalistaID", jornalista.Id);
            return View(jornalista);
        }

        // POST: Jornalistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Fotojor")] Jornalistas jornalista, IFormFile fotoJornalista)
        {
            if (id != jornalista.Id)
            {
                return NotFound();
            }

            var idJornalista = HttpContext.Session.GetInt32("JornalistaID");

            if (idJornalista == null)
            {
                
                ModelState.AddModelError("", "Demorou demasiado tempo a executar a tarefa de edição");
                return View(jornalista);
            }

           
            if (idJornalista != jornalista.Id)
            {
                
                return RedirectToAction("Index");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornalista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornalistasExists(jornalista.Id))
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
            return View(jornalista);
        }

        // GET: Jornalistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
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
            try
            {
                var jornalista = await _context.Jornalistas.FindAsync(id);
                _context.Jornalistas.Remove(jornalista);
                await _context.SaveChangesAsync();

                // remover o ficheiro com a foto do Jornalista
                // se a foto NÃO FOR a 'noJornalista.png'
            }
            catch (Exception)
            {
                //   throw;
                // não esquecer, tratar da exceção
            }

            return RedirectToAction(nameof(Index));
        }

        private bool JornalistasExists(int id)
        {
          return _context.Jornalistas.Any(e => e.Id == id);
        }
    }
}
