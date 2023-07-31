using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipiOrdineController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public TipiOrdineController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/TipiOrdine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOrdine>>> GetTipiOrdine()
        {
          if (_context.TipiOrdine == null)
          {
              return NotFound();
          }
            return await _context.TipiOrdine.ToListAsync();
        }

        // GET: api/TipiOrdine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOrdine>> GetTipoOrdine(int id)
        {
          if (_context.TipiOrdine == null)
          {
              return NotFound();
          }
            var tipoOrdine = await _context.TipiOrdine.FindAsync(id);

            if (tipoOrdine == null)
            {
                return NotFound();
            }

            return tipoOrdine;
        }

        // PUT: api/TipiOrdine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOrdine(int id, TipoOrdine tipoOrdine)
        {
            if (id != tipoOrdine.IdTipo)
            {
                return BadRequest();
            }

            _context.Entry(tipoOrdine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOrdineExists(id))
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

        // POST: api/TipiOrdine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoOrdine>> PostTipoOrdine(TipoOrdine tipoOrdine)
        {
          if (_context.TipiOrdine == null)
          {
              return Problem("Entity set 'BirriamoDemoContext.TipiOrdine'  is null.");
          }
            _context.TipiOrdine.Add(tipoOrdine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoOrdine", new { id = tipoOrdine.IdTipo }, tipoOrdine);
        }

        // DELETE: api/TipiOrdine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoOrdine(int id)
        {
            if (_context.TipiOrdine == null)
            {
                return NotFound();
            }
            var tipoOrdine = await _context.TipiOrdine.FindAsync(id);
            if (tipoOrdine == null)
            {
                return NotFound();
            }

            _context.TipiOrdine.Remove(tipoOrdine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoOrdineExists(int id)
        {
            return (_context.TipiOrdine?.Any(e => e.IdTipo == id)).GetValueOrDefault();
        }
    }
}
