using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppuntamentiController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public AppuntamentiController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Appuntamenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appuntamenti>>> GetAppuntamenti()
        {
          if (_context.Appuntamenti == null)
          {
              return NotFound();
          }
            return await _context.Appuntamenti.ToListAsync();
        }

        // GET: api/Appuntamenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appuntamenti>> GetAppuntamenti(int id)
        {
          if (_context.Appuntamenti == null)
          {
              return NotFound();
          }
            var appuntamenti = await _context.Appuntamenti.FindAsync(id);

            if (appuntamenti == null)
            {
                return NotFound();
            }

            return appuntamenti;
        }

        // PUT: api/Appuntamenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppuntamenti(int id, Appuntamenti appuntamenti)
        {
            if (id != appuntamenti.Id)
            {
                return BadRequest();
            }

            _context.Entry(appuntamenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppuntamentiExists(id))
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

        // POST: api/Appuntamenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appuntamenti>> PostAppuntamenti(Appuntamenti appuntamenti)
        {
          if (_context.Appuntamenti == null)
          {
              return Problem("Entity set 'BirriamoDemoContext.Appuntamenti'  is null.");
          }
            _context.Appuntamenti.Add(appuntamenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppuntamenti", new { id = appuntamenti.Id }, appuntamenti);
        }

        // DELETE: api/Appuntamenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppuntamenti(int id)
        {
            if (_context.Appuntamenti == null)
            {
                return NotFound();
            }
            var appuntamenti = await _context.Appuntamenti.FindAsync(id);
            if (appuntamenti == null)
            {
                return NotFound();
            }

            _context.Appuntamenti.Remove(appuntamenti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppuntamentiExists(int id)
        {
            return (_context.Appuntamenti?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
