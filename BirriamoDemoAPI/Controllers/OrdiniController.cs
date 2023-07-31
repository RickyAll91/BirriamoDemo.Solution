using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdiniController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public OrdiniController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Ordini
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordine>>> GetOrdini()
        {
            if (_context.Ordini == null)
            {
                return NotFound();
            }
            return await _context.Ordini.ToListAsync();
        }

        // GET: api/Ordini/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordine>> GetOrdine(int id)
        {
            if (_context.Ordini == null)
            {
                return NotFound();
            }
            var ordine = await _context.Ordini.FindAsync(id);

            if (ordine == null)
            {
                return NotFound();
            }

            return ordine;
        }

        // PUT: api/Ordini/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdine(int id, Ordine ordine)
        {
            if (id != ordine.IdOrdine)
            {
                return BadRequest();
            }

            _context.Entry(ordine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdineExists(id))
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

        // POST: api/Ordini
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordine>> PostOrdine(Ordine ordine)
        {
            if (_context.Ordini == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Ordini'  is null.");
            }
            _context.Ordini.Add(ordine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdine", new { id = ordine.IdOrdine }, ordine);
        }

        // DELETE: api/Ordini/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdine(int id)
        {
            if (_context.Ordini == null)
            {
                return NotFound();
            }
            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }

            _context.Ordini.Remove(ordine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdineExists(int id)
        {
            return (_context.Ordini?.Any(e => e.IdOrdine == id)).GetValueOrDefault();
        }
    }
}
