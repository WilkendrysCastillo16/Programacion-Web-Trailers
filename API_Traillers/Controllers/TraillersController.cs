using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Traillers.Models;

namespace API_Traillers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraillersController : ControllerBase
    {
        private readonly dbTraillerContext _context;

        public TraillersController(dbTraillerContext context)
        {
            _context = context;
        }

        // GET: api/Traillers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trailler>>> GetTraillers()
        {
            return await _context.Traillers.ToListAsync();
        }

        // GET: api/Traillers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trailler>> GetTrailler(int id)
        {
            var trailler = await _context.Traillers.FindAsync(id);

            if (trailler == null)
            {
                return NotFound();
            }

            return trailler;
        }

        // PUT: api/Traillers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrailler(int id, Trailler trailler)
        {
            if (id != trailler.Id)
            {
                return BadRequest();
            }

            _context.Entry(trailler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraillerExists(id))
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

        // POST: api/Traillers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trailler>> PostTrailler(Trailler trailler)
        {
            _context.Traillers.Add(trailler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrailler", new { id = trailler.Id }, trailler);
        }

        // DELETE: api/Traillers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrailler(int id)
        {
            var trailler = await _context.Traillers.FindAsync(id);
            if (trailler == null)
            {
                return NotFound();
            }

            _context.Traillers.Remove(trailler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraillerExists(int id)
        {
            return _context.Traillers.Any(e => e.Id == id);
        }
    }
}
