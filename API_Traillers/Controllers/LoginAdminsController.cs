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
    public class LoginAdminsController : ControllerBase
    {
        private readonly dbTraillerContext _context;

        public LoginAdminsController(dbTraillerContext context)
        {
            _context = context;
        }

        // GET: api/LoginAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginAdmin>>> GetLoginAdmins()
        {
            return await _context.LoginAdmins.ToListAsync();
        }

        // GET: api/LoginAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginAdmin>> GetLoginAdmin(int id)
        {
            var loginAdmin = await _context.LoginAdmins.FindAsync(id);

            if (loginAdmin == null)
            {
                return NotFound();
            }

            return loginAdmin;
        }

        // PUT: api/LoginAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginAdmin(int id, LoginAdmin loginAdmin)
        {
            if (id != loginAdmin.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginAdminExists(id))
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

        // POST: api/LoginAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginAdmin>> PostLoginAdmin(LoginAdmin loginAdmin)
        {
            _context.LoginAdmins.Add(loginAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginAdmin", new { id = loginAdmin.Id }, loginAdmin);
        }

        // DELETE: api/LoginAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginAdmin(int id)
        {
            var loginAdmin = await _context.LoginAdmins.FindAsync(id);
            if (loginAdmin == null)
            {
                return NotFound();
            }

            _context.LoginAdmins.Remove(loginAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginAdminExists(int id)
        {
            return _context.LoginAdmins.Any(e => e.Id == id);
        }
    }
}
