using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AboutItemsController : ControllerBase
    {
        private readonly AboutContext _context;

        public AboutItemsController(AboutContext context)
        {
            _context = context;
        }

        // GET: api/AboutItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutItem>>> GetTodoItems()
        {
          if (_context.AboutItems == null)
          {
              return NotFound();
          }
            return await _context.AboutItems.ToListAsync();
        }

        // GET: api/AboutItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutItem>> GetAboutItem(long id)
        {
          if (_context.AboutItems == null)
          {
              return NotFound();
          }
            var aboutItem = await _context.AboutItems.FindAsync(id);

            if (aboutItem == null)
            {
                return NotFound();
            }

            return aboutItem;
        }

        // PUT: api/AboutItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAboutItem(long id, AboutItem aboutItem)
        {
            if (id != aboutItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(aboutItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutItemExists(id))
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

        // POST: api/AboutItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AboutItem>> PostAboutItem(AboutItem aboutItem)
        {
         
            _context.AboutItems.Add(aboutItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAboutItem), new { id = aboutItem.Id }, aboutItem);
        }

        // DELETE: api/AboutItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutItem(long id)
        {
            if (_context.AboutItems == null)
            {
                return NotFound();
            }
            var aboutItem = await _context.AboutItems.FindAsync(id);
            if (aboutItem == null)
            {
                return NotFound();
            }

            _context.AboutItems.Remove(aboutItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AboutItemExists(long id)
        {
            return (_context.AboutItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    private static AboutItemDTO ItemToDTO(AboutItem AboutItem) =>
       new AboutItemDTO
       {
           Id = AboutItem.Id,
           Name = AboutItem.Name,
           IsComplete = AboutItem.IsComplete
       };
}

