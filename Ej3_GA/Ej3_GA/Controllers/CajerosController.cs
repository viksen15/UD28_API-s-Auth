using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ej3_GA.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ej3_GA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CajerosController : ControllerBase
    {
        private readonly T28_Ej3_GAContext _context;

        public CajerosController(T28_Ej3_GAContext context)
        {
            _context = context;
        }

        // GET: api/Cajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajeros>>> GetCajeros()
        {
            return await _context.Cajeros.ToListAsync();
        }

        // GET: api/Cajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cajeros>> GetCajeros(int id)
        {
            var cajeros = await _context.Cajeros.FindAsync(id);

            if (cajeros == null)
            {
                return NotFound();
            }

            return cajeros;
        }

        // PUT: api/Cajeros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCajeros(int id, Cajeros cajeros)
        {
            if (id != cajeros.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(cajeros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajerosExists(id))
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

        // POST: api/Cajeros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cajeros>> PostCajeros(Cajeros cajeros)
        {
            _context.Cajeros.Add(cajeros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCajeros", new { id = cajeros.Codigo }, cajeros);
        }

        // DELETE: api/Cajeros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cajeros>> DeleteCajeros(int id)
        {
            var cajeros = await _context.Cajeros.FindAsync(id);
            if (cajeros == null)
            {
                return NotFound();
            }

            _context.Cajeros.Remove(cajeros);
            await _context.SaveChangesAsync();

            return cajeros;
        }

        private bool CajerosExists(int id)
        {
            return _context.Cajeros.Any(e => e.Codigo == id);
        }
    }
}
