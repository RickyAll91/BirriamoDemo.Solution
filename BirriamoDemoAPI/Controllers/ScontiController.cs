using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScontiController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public ScontiController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Sconti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sconti>>> GetSconti()
        {
            if (_context.Sconti == null)
            {
                return NotFound();
            }
            return await _context.Sconti.ToListAsync();
        }

        // GET: api/Sconti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sconti>> GetSconti(int id)
        {
            if (_context.Sconti == null)
            {
                return NotFound();
            }
            var sconti = await _context.Sconti.FindAsync(id);

            if (sconti == null)
            {
                return NotFound();
            }

            return sconti;
        }

        // PUT: api/Sconti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSconti(int id, Sconti sconti)
        {
            if (id != sconti.IdSconto)
            {
                return BadRequest();
            }

            _context.Entry(sconti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScontiExists(id))
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

        // POST: api/Sconti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sconti>> PostSconti(Sconti sconti)
        {
            if (_context.Sconti == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Sconti'  is null.");
            }
            _context.Sconti.Add(sconti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSconti", new { id = sconti.IdSconto }, sconti);
        }

        // DELETE: api/Sconti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSconti(int id)
        {
            if (_context.Sconti == null)
            {
                return NotFound();
            }
            var sconti = await _context.Sconti.FindAsync(id);
            if (sconti == null)
            {
                return NotFound();
            }

            _context.Sconti.Remove(sconti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScontiExists(int id)
        {
            return (_context.Sconti?.Any(e => e.IdSconto == id)).GetValueOrDefault();
        }
    }
}
