using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ej4_I.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ej4_I.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigadoresController : ControllerBase
    {
        private readonly T28_Ej4_IContext _context;

        public InvestigadoresController(T28_Ej4_IContext context)
        {
            _context = context;
        }

        // GET: api/Investigadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigadores>>> GetInvestigadores()
        {
            return await _context.Investigadores.ToListAsync();
        }

        // GET: api/Investigadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigadores>> GetInvestigadores(string id)
        {
            var investigadores = await _context.Investigadores.FindAsync(id);

            if (investigadores == null)
            {
                return NotFound();
            }

            return investigadores;
        }

        // PUT: api/Investigadores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigadores(string id, Investigadores investigadores)
        {
            if (id != investigadores.Dni)
            {
                return BadRequest();
            }

            _context.Entry(investigadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigadoresExists(id))
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

        // POST: api/Investigadores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Investigadores>> PostInvestigadores(Investigadores investigadores)
        {
            _context.Investigadores.Add(investigadores);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvestigadoresExists(investigadores.Dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvestigadores", new { id = investigadores.Dni }, investigadores);
        }

        // DELETE: api/Investigadores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Investigadores>> DeleteInvestigadores(string id)
        {
            var investigadores = await _context.Investigadores.FindAsync(id);
            if (investigadores == null)
            {
                return NotFound();
            }

            _context.Investigadores.Remove(investigadores);
            await _context.SaveChangesAsync();

            return investigadores;
        }

        private bool InvestigadoresExists(string id)
        {
            return _context.Investigadores.Any(e => e.Dni == id);
        }
    }
}
