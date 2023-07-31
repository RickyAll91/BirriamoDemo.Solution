using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuoliController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public RuoliController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Ruoli
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruoli>>> GetRuoli()
        {
            if (_context.Ruoli == null)
            {
                return NotFound();
            }
            return await _context.Ruoli.ToListAsync();
        }

        // GET: api/Ruoli/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruoli>> GetRuoli(int id)
        {
            if (_context.Ruoli == null)
            {
                return NotFound();
            }
            var ruoli = await _context.Ruoli.FindAsync(id);

            if (ruoli == null)
            {
                return NotFound();
            }

            return ruoli;
        }

        // PUT: api/Ruoli/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuoli(int id, Ruoli ruoli)
        {
            if (id != ruoli.Id)
            {
                return BadRequest();
            }

            _context.Entry(ruoli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuoliExists(id))
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

        // POST: api/Ruoli
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ruoli>> PostRuoli(Ruoli ruoli)
        {
            if (_context.Ruoli == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Ruoli'  is null.");
            }
            _context.Ruoli.Add(ruoli);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuoli", new { id = ruoli.Id }, ruoli);
        }

        // DELETE: api/Ruoli/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuoli(int id)
        {
            if (_context.Ruoli == null)
            {
                return NotFound();
            }
            var ruoli = await _context.Ruoli.FindAsync(id);
            if (ruoli == null)
            {
                return NotFound();
            }

            _context.Ruoli.Remove(ruoli);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RuoliExists(int id)
        {
            return (_context.Ruoli?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
