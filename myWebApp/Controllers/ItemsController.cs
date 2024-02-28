
using myWebApp.Shared.Models;
using myWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace myWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly mySQLDbContext _WebApiDbContext;

        public ItemsController(mySQLDbContext WebApiDbContext)
        {
            _WebApiDbContext = WebApiDbContext;
            _WebApiDbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            if (_WebApiDbContext.Items == null)
            {
                return NotFound();
            }
            return await _WebApiDbContext.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int Id)
        {
            if (_WebApiDbContext.Items == null)
            {
                return NotFound();
            }
            try
            {
                var Item = await _WebApiDbContext.Items.FindAsync(Id);
                if (Item == null)
                {
                    return NotFound();
                }

                return Item;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return NotFound();
            }


        }

        // POST: api/Items      Add Item
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item Item)
        {
            if (!ItemExists(Item.Id))
            {
                try
                {
                    _WebApiDbContext.Items.Add(Item);
                    await _WebApiDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                    return BadRequest();
                }
            }


            return CreatedAtAction(nameof(GetItem), new { Id = Item.Id }, Item);
        }

        // PUT: api/Items/5     //Update
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutItem(int Id, Item Item)
        {
            if (Id != Item.Id)
            {
                return BadRequest();
            }

            _WebApiDbContext.Entry(Item).State = EntityState.Modified;

            try
            {
                await _WebApiDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Id))
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

        // DELETE: api/Items/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteItem(int Id)
        {
            if (_WebApiDbContext.Items == null)
            {
                return NotFound();
            }

            var Item = await _WebApiDbContext.Items.FindAsync(Id);
            if (Item == null)
            {
                return NotFound();
            }

            _WebApiDbContext.Items.Remove(Item);
            await _WebApiDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int Id)
        {
            return (_WebApiDbContext.Items?.Any(i => i.Id == Id)).GetValueOrDefault();
        }
    }
}