using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmazemDoMago.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArmazemDoMago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicItemsController : ControllerBase
    {
        private readonly ItemContext _context;

        public MagicItemsController(ItemContext context)
        {
            _context = context;
        }
        // GET: api/MagicItems
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagicItem>>> GetMagicItems() {
            if (_context.MagicItems == null) {
                return Problem("Entity set 'ItemContext.MagicItems' is null.");
            }

            // Classifique os itens com base no poder mágico (supondo que o poder mágico seja uma propriedade chamada "MagicPower").
            var sortedItems = await _context.MagicItems.OrderByDescending(item => item.MagicPower).ToListAsync();

            return sortedItems;
        }


        // GET: api/MagicItems/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<MagicItem>> GetMagicItem(int id)
        {
          if (_context.MagicItems == null)
          {
              return NotFound();
          }
            var magicItem = await _context.MagicItems.FindAsync(id);

            if (magicItem == null)
            {
                return NotFound();
            }

            return magicItem;
        }

        // PUT: api/MagicItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagicItem(int id, MagicItem magicItem)
        {
            if (id != magicItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(magicItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagicItemExists(id))
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

        // POST: api/MagicItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<MagicItem>> PostMagicItem(MagicItem magicItem)
        {
          if (_context.MagicItems == null)
          {
              return Problem("Entity set 'ItemContext.MagicItems'  is null.");
          }
            _context.MagicItems.Add(magicItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMagicItem), new { id = magicItem.Id }, magicItem);
        }

        // GET: api/MagicItems/Alert/{itemId}
        [Authorize]
        [HttpGet("Alert/{itemId}")]
        public async Task<ActionResult<string>> GetItemAlert(int itemId) {
            if (_context.MagicItems == null) {
                return Problem("Entity set 'ItemContext.MagicItems' is null.");
            }

            var magicItem = await _context.MagicItems.FindAsync(itemId);

            if (magicItem == null) {
                return NotFound("Item não encontrado.");
            }

            if (magicItem.Quantity < 3) {
                // Aqui você pode criar uma mensagem de alerta ou tomar alguma ação.
                // Neste exemplo, estamos retornando uma mensagem de alerta.
                return Ok("Alerta: Você tem menos de 3 unidades deste item.");
            }

            return Ok("Você tem 3 ou mais unidades deste item.");
        }


        // DELETE: api/MagicItems/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagicItem(int id)
        {
            if (_context.MagicItems == null)
            {
                return NotFound();
            }
            var magicItem = await _context.MagicItems.FindAsync(id);
            if (magicItem == null)
            {
                return NotFound();
            }

            _context.MagicItems.Remove(magicItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagicItemExists(int id)
        {
            return (_context.MagicItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
