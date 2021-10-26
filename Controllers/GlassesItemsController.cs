using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassesApi.Models;

namespace GlassesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlassesItemsController : ControllerBase
    {
        private readonly GlassesContext _context;

        public GlassesItemsController(GlassesContext context)
        {
            _context = context;
        }

        // GET: api/GlassesItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlassesItem>>> GetGlassesItems()
        {
            return await _context.GlassesItems.ToListAsync();
        }

        // GET: api/GlassesItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlassesItem>> GetGlassesItem(long id)
        {
            var glassesItem = await _context.GlassesItems.FindAsync(id);

            if (glassesItem == null)
            {
                return NotFound();
            }

            return glassesItem;
        }

        // PUT: api/GlassesItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlassesItem(long id, GlassesItem glassesItem)
        {
            if (id != glassesItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(glassesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlassesItemExists(id))
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

        // POST: api/GlassesItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GlassesItem>> PostGlassesItem(GlassesItem glassesItem)
        {
            _context.GlassesItems.Add(glassesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGlassesItem), new { id = glassesItem.Id }, glassesItem);
        }

        // DELETE: api/GlassesItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlassesItem(long id)
        {
            var glassesItem = await _context.GlassesItems.FindAsync(id);
            if (glassesItem == null)
            {
                return NotFound();
            }

            _context.GlassesItems.Remove(glassesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GlassesItemExists(long id)
        {
            return _context.GlassesItems.Any(e => e.Id == id);
        }
    }
}
