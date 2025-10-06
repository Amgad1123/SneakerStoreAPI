using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakerStoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SneakerStoreAPI.Controllers
{
        
    [Route("api/[controller]")]
    [ApiController]
    public class SneakersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SneakersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sneaker>>> GetSneakers()
        {
            return await _context.Sneakers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sneaker>> GetSneaker(int id)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound();
            }
            return Ok(sneaker);
        }

        
        [HttpPost]
        public async Task<ActionResult<Sneaker>> AddSneaker([FromBody] Sneaker sneaker)
        {
            _context.Sneakers.Add(sneaker);
            await _context.SaveChangesAsync();
            return Ok(sneaker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSneaker(int id, [FromBody] Sneaker sneaker)
        {
            if (id != sneaker.Id)
            {
                return BadRequest();
            }

            _context.Entry(sneaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSneaker(int id)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound();
            }

            _context.Sneakers.Remove(sneaker);
            await _context.SaveChangesAsync();
            return Ok(sneaker);
        }
    }
}

