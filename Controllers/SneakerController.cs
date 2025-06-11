using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakerStoreAPI.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace SneakerStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : Controller
    {
        private readonly AppDbContext _context;
        public SneakerController(AppDbContext context)
        {
            _context = context;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<Sneaker>>> GetSneakers()
        {
            return await _context.Sneakers.ToListAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Sneaker>>> GetSneaker(int id)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound();
            }
            return Ok(sneaker);
        }

        [Authorize(Roles = "Admin")]
        [System.Web.Http.HttpPost]
        public async Task<ActionResult<IEnumerable<Sneaker>>> AddSneaker(Sneaker sneaker)
        {
            _context.Sneakers.Add(sneaker);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSneaker), new { id = sneaker.Id }, sneaker);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> UpdateSneaker(int id, Sneaker sneaker)
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

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Sneaker>>> DeleteSneaker(int id)
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
