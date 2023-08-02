using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiacenzeController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public GiacenzeController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Giacenzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giacenze>>> GetGiacenze()
        {
            if (_context.Giacenze == null)
            {
                return NotFound();
            }
            return await _context.Giacenze.Include(x => x.IdProdottoNavigation).ToListAsync();
        }

        // GET: api/Giacenzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giacenze>> GetGiacenze(int id)
        {
            if (_context.Giacenze == null)
            {
                return NotFound();
            }
            var giacenze = await _context.Giacenze.FindAsync(id);

            if (giacenze == null)
            {
                return NotFound();
            }

            return giacenze;
        }

        // PUT: api/Giacenzes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiacenze(int id, Giacenze giacenze)
        {
            if (id != giacenze.Id)
            {
                return BadRequest();
            }

            _context.Entry(giacenze).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiacenzeExists(id))
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

        // POST: api/Giacenzes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giacenze>> PostGiacenze(Giacenze giacenze)
        {
            if (_context.Giacenze == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Giacenze'  is null.");
            }
            _context.Giacenze.Add(giacenze);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiacenze", new { id = giacenze.Id }, giacenze);
        }

        // DELETE: api/Giacenzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiacenze(int id)
        {
            if (_context.Giacenze == null)
            {
                return NotFound();
            }
            var giacenze = await _context.Giacenze.FindAsync(id);
            if (giacenze == null)
            {
                return NotFound();
            }

            _context.Giacenze.Remove(giacenze);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiacenzeExists(int id)
        {
            return (_context.Giacenze?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
