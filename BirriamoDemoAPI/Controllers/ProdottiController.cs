using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private readonly BirriamoDemoContext _context;

        public ProdottiController(BirriamoDemoContext context)
        {
            _context = context;
        }

        // GET: api/Prodottoi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodotto>>> GetProdotti()
        {
            if (_context.Prodotti == null)
            {
                return NotFound();
            }
            return await _context.Prodotti.ToListAsync();
        }

        // GET: api/Prodottoi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodotto>> GetProdotto(int id)
        {
            if (_context.Prodotti == null)
            {
                return NotFound();
            }
            var prodotto = await _context.Prodotti.FindAsync(id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return prodotto;
        }

        // PUT: api/Prodottoi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdotto(int id, Prodotto prodotto)
        {
            if (id != prodotto.Id)
            {
                return BadRequest();
            }

            _context.Entry(prodotto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdottoExists(id))
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

        // POST: api/Prodottoi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prodotto>> PostProdotto(Prodotto prodotto)
        {
            if (_context.Prodotti == null)
            {
                return Problem("Entity set 'BirriamoDemoContext.Prodotti'  is null.");
            }
            _context.Prodotti.Add(prodotto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdotto", new { id = prodotto.Id }, prodotto);
        }

        // DELETE: api/Prodottoi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdotto(int id)
        {
            if (_context.Prodotti == null)
            {
                return NotFound();
            }
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }

            _context.Prodotti.Remove(prodotto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdottoExists(int id)
        {
            return (_context.Prodotti?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
