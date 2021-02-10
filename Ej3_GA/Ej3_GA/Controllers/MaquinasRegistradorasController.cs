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
    public class MaquinasRegistradorasController : ControllerBase
    {
        private readonly T28_Ej3_GAContext _context;

        public MaquinasRegistradorasController(T28_Ej3_GAContext context)
        {
            _context = context;
        }

        // GET: api/MaquinasRegistradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaquinasRegistradoras>>> GetMaquinasRegistradoras()
        {
            return await _context.MaquinasRegistradoras.ToListAsync();
        }

        // GET: api/MaquinasRegistradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinasRegistradoras>> GetMaquinasRegistradoras(int id)
        {
            var maquinasRegistradoras = await _context.MaquinasRegistradoras.FindAsync(id);

            if (maquinasRegistradoras == null)
            {
                return NotFound();
            }

            return maquinasRegistradoras;
        }

        // PUT: api/MaquinasRegistradoras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinasRegistradoras(int id, MaquinasRegistradoras maquinasRegistradoras)
        {
            if (id != maquinasRegistradoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquinasRegistradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinasRegistradorasExists(id))
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

        // POST: api/MaquinasRegistradoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaquinasRegistradoras>> PostMaquinasRegistradoras(MaquinasRegistradoras maquinasRegistradoras)
        {
            _context.MaquinasRegistradoras.Add(maquinasRegistradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinasRegistradoras", new { id = maquinasRegistradoras.Codigo }, maquinasRegistradoras);
        }

        // DELETE: api/MaquinasRegistradoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaquinasRegistradoras>> DeleteMaquinasRegistradoras(int id)
        {
            var maquinasRegistradoras = await _context.MaquinasRegistradoras.FindAsync(id);
            if (maquinasRegistradoras == null)
            {
                return NotFound();
            }

            _context.MaquinasRegistradoras.Remove(maquinasRegistradoras);
            await _context.SaveChangesAsync();

            return maquinasRegistradoras;
        }

        private bool MaquinasRegistradorasExists(int id)
        {
            return _context.MaquinasRegistradoras.Any(e => e.Codigo == id);
        }
    }
}
