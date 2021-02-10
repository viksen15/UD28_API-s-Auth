using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ej2_C_Auth.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ej2_C_Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AsignadoAController : ControllerBase
    {
        private readonly T28_Ej2_CContext _context;

        public AsignadoAController(T28_Ej2_CContext context)
        {
            _context = context;
        }

        // GET: api/AsignadoA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignadoA>>> GetAsignadoA()
        {
            return await _context.AsignadoA.ToListAsync();
        }

        // GET: api/AsignadoA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignadoA>> GetAsignadoA(string id)
        {
            var asignadoA = await _context.AsignadoA.FindAsync(id);

            if (asignadoA == null)
            {
                return NotFound();
            }

            return asignadoA;
        }

        // PUT: api/AsignadoA/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignadoA(string id, AsignadoA asignadoA)
        {
            if (id != asignadoA.Cientifico)
            {
                return BadRequest();
            }

            _context.Entry(asignadoA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignadoAExists(id))
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

        // POST: api/AsignadoA
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AsignadoA>> PostAsignadoA(AsignadoA asignadoA)
        {
            _context.AsignadoA.Add(asignadoA);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignadoAExists(asignadoA.Cientifico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignadoA", new { id = asignadoA.Cientifico }, asignadoA);
        }

        // DELETE: api/AsignadoA/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AsignadoA>> DeleteAsignadoA(string id)
        {
            var asignadoA = await _context.AsignadoA.FindAsync(id);
            if (asignadoA == null)
            {
                return NotFound();
            }

            _context.AsignadoA.Remove(asignadoA);
            await _context.SaveChangesAsync();

            return asignadoA;
        }

        private bool AsignadoAExists(string id)
        {
            return _context.AsignadoA.Any(e => e.Cientifico == id);
        }
    }
}
