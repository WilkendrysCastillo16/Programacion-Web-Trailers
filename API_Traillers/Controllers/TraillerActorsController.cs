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
    public class TraillerActorsController : ControllerBase
    {
        private readonly dbTraillerContext _context;

        public TraillerActorsController(dbTraillerContext context)
        {
            _context = context;
        }

        // GET: api/TraillerActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraillerActor>>> GetTraillerActors()
        {
            return await _context.TraillerActors.ToListAsync();
        }

        // GET: api/TraillerActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraillerActor>> GetTraillerActor(int id)
        {
            var traillerActor = await _context.TraillerActors.FindAsync(id);

            if (traillerActor == null)
            {
                return NotFound();
            }

            return traillerActor;
        }

        // PUT: api/TraillerActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraillerActor(int id, TraillerActor traillerActor)
        {
            if (id != traillerActor.Id)
            {
                return BadRequest();
            }

            _context.Entry(traillerActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraillerActorExists(id))
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

        // POST: api/TraillerActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraillerActor>> PostTraillerActor(TraillerActor traillerActor)
        {
            _context.TraillerActors.Add(traillerActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraillerActor", new { id = traillerActor.Id }, traillerActor);
        }

        // DELETE: api/TraillerActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraillerActor(int id)
        {
            var traillerActor = await _context.TraillerActors.FindAsync(id);
            if (traillerActor == null)
            {
                return NotFound();
            }

            _context.TraillerActors.Remove(traillerActor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraillerActorExists(int id)
        {
            return _context.TraillerActors.Any(e => e.Id == id);
        }
    }
}
