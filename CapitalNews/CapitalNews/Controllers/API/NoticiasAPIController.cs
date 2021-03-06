using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapitalNews.Data;
using CapitalNews.Models;

namespace CapitalNews.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasAPIController : ControllerBase
    {
        private readonly CapitalDb _context;

        public NoticiasAPIController(CapitalDb context)
        {
            _context = context;
        }

        // GET: api/NoticiasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticiasViewModel>>> GetNoticias()
        {
            return await _context.Noticias
                .Include(n => n.Categoria)
                .Include(n => n.Jornalista)
                .Include(n => n.Fotografia)
                .OrderByDescending(a => a.Data)
                .Select(n => new NoticiasViewModel
                {
                    Id = n.Id,
                    Titulo = n.Titulo,
                    Body = n.Body,
                    Data = n.Data,
                    Categoria = n.Categoria.CategoriaNome,
                    Jornalista = n.Jornalista.Nome,
                    Fotografia = n.Fotografia.NomeFoto

                })
                .ToListAsync();
        }

        // GET: api/NoticiasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticias>> GetNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);

            if (noticias == null)
            {
                return NotFound();
            }

            return noticias;
        }

        // PUT: api/NoticiasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(int id, Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return BadRequest();
            }

            _context.Entry(noticias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NoticiasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias([FromForm] Noticias noticias)
        {
            noticias.FotografiaFK = 1;
            noticias.JornalistaFK = 1;
            try
            {
                _context.Noticias.Add(noticias);
                await _context.SaveChangesAsync();
            }
            catch (Exception x)
            {
                throw x;
            }

            return CreatedAtAction("GetNoticias", new { id = noticias.Id }, noticias);
        }

        // DELETE: api/NoticiasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }

            _context.Noticias.Remove(noticias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoticiasExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}