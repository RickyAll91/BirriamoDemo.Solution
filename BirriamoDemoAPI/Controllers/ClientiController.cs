using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientiController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public ClientiController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Clienti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clienti>>> GetClienti()
        {
            if (_context.Clienti == null)
            {
                return NotFound();
            }
            return await _context.Clienti.ToListAsync();
        }

        // GET: api/Clienti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clienti>> GetClienti(int id)
        {
            if (_context.Clienti == null)
            {
                return NotFound();
            }
            var clienti = await _context.Clienti.FindAsync(id);

            if (clienti == null)
            {
                return NotFound();
            }

            return clienti;
        }

        // PUT: api/Clienti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienti(int id, Clienti clienti)
        {
            if (id != clienti.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(clienti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientiExists(id))
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

        // POST: api/Clienti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clienti>> PostClienti(Clienti clienti)
        {
            if (_context.Clienti == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Clienti'  is null.");
            }
            _context.Clienti.Add(clienti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienti", new { id = clienti.IdCliente }, clienti);
        }

        // DELETE: api/Clienti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienti(int id)
        {
            if (_context.Clienti == null)
            {
                return NotFound();
            }
            var clienti = await _context.Clienti.FindAsync(id);
            if (clienti == null)
            {
                return NotFound();
            }

            _context.Clienti.Remove(clienti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientiExists(int id)
        {
            return (_context.Clienti?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
