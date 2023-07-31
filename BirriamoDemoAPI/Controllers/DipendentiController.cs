using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipendentiController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public DipendentiController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Dipendentis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dipendenti>>> GetDipendenti()
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            return await _context.Dipendenti.ToListAsync();
        }

        // GET: api/Dipendentis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dipendenti>> GetDipendenti(int id)
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            var dipendenti = await _context.Dipendenti.FindAsync(id);

            if (dipendenti == null)
            {
                return NotFound();
            }

            return dipendenti;
        }

        // PUT: api/Dipendentis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDipendenti(int id, Dipendenti dipendenti)
        {
            if (id != dipendenti.Matricola)
            {
                return BadRequest();
            }

            _context.Entry(dipendenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DipendentiExists(id))
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

        // POST: api/Dipendentis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dipendenti>> PostDipendenti(Dipendenti dipendenti)
        {
            if (_context.Dipendenti == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Dipendenti'  is null.");
            }
            _context.Dipendenti.Add(dipendenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDipendenti", new { id = dipendenti.Matricola }, dipendenti);
        }

        // DELETE: api/Dipendentis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDipendenti(int id)
        {
            if (_context.Dipendenti == null)
            {
                return NotFound();
            }
            var dipendenti = await _context.Dipendenti.FindAsync(id);
            if (dipendenti == null)
            {
                return NotFound();
            }

            _context.Dipendenti.Remove(dipendenti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DipendentiExists(int id)
        {
            return (_context.Dipendenti?.Any(e => e.Matricola == id)).GetValueOrDefault();
        }
    }
}
