using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DettaglioOrdiniController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public DettaglioOrdiniController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/DettaglioOrdines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DettaglioOrdine>>> GetDettaglioOrdine()
        {
            if (_context.DettaglioOrdine == null)
            {
                return NotFound();
            }
            return await _context.DettaglioOrdine.ToListAsync();
        }

        // GET: api/DettaglioOrdines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DettaglioOrdine>> GetDettaglioOrdine(int id)
        {
            if (_context.DettaglioOrdine == null)
            {
                return NotFound();
            }
            var dettaglioOrdine = await _context.DettaglioOrdine.FindAsync(id);

            if (dettaglioOrdine == null)
            {
                return NotFound();
            }

            return dettaglioOrdine;
        }

        // PUT: api/DettaglioOrdines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDettaglioOrdine(int id, DettaglioOrdine dettaglioOrdine)
        {
            if (id != dettaglioOrdine.Id)
            {
                return BadRequest();
            }

            _context.Entry(dettaglioOrdine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DettaglioOrdineExists(id))
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

        // POST: api/DettaglioOrdines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DettaglioOrdine>> PostDettaglioOrdine(DettaglioOrdine dettaglioOrdine)
        {
            if (_context.DettaglioOrdine == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.DettaglioOrdine'  is null.");
            }
            _context.DettaglioOrdine.Add(dettaglioOrdine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDettaglioOrdine", new { id = dettaglioOrdine.Id }, dettaglioOrdine);
        }

        // DELETE: api/DettaglioOrdines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDettaglioOrdine(int id)
        {
            if (_context.DettaglioOrdine == null)
            {
                return NotFound();
            }
            var dettaglioOrdine = await _context.DettaglioOrdine.FindAsync(id);
            if (dettaglioOrdine == null)
            {
                return NotFound();
            }

            _context.DettaglioOrdine.Remove(dettaglioOrdine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DettaglioOrdineExists(int id)
        {
            return (_context.DettaglioOrdine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
