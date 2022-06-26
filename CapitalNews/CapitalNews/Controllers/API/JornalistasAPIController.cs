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
    public class JornalistasAPIController : ControllerBase
    {
        private readonly CapitalDb _context;

        public JornalistasAPIController(CapitalDb context)
        {
            _context = context;
        }

        // GET: api/JornalistasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JornalistasViewModel>>> GetJornalistas()
        {
            return await _context.Jornalistas
                .OrderBy(j => j.Nome)
                .Select(j => new JornalistasViewModel
                {
                    Id = j.Id,
                    Nome = j.Nome,
                    
                })
                .ToListAsync();
        }

        // GET: api/JornalistasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jornalistas>> GetJornalistas(int id)
        {
            var jornalistas = await _context.Jornalistas.FindAsync(id);

            if (jornalistas == null)
            {
                return NotFound();
            }

            return jornalistas;
        }

        // PUT: api/JornalistasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJornalistas(int id, Jornalistas jornalistas)
        {
            if (id != jornalistas.Id)
            {
                return BadRequest();
            }

            _context.Entry(jornalistas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornalistasExists(id))
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

        // POST: api/JornalistasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jornalistas>> PostJornalistas(Jornalistas jornalistas)
        {
            _context.Jornalistas.Add(jornalistas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJornalistas", new { id = jornalistas.Id }, jornalistas);
        }

        // DELETE: api/JornalistasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJornalistas(int id)
        {
            var jornalistas = await _context.Jornalistas.FindAsync(id);
            if (jornalistas == null)
            {
                return NotFound();
            }

            _context.Jornalistas.Remove(jornalistas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JornalistasExists(int id)
        {
            return _context.Jornalistas.Any(e => e.Id == id);
        }
    }
}
