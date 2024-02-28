
using myWebApp.Shared.Models;
using myWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace myWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase {
        private readonly mySQLDbContext _WebApiDbContext;

        public ItemsController(mySQLDbContext WebApiDbContext) {
            _WebApiDbContext = WebApiDbContext;
            _WebApiDbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems() {
            if (_WebApiDbContext.Items == null) {
                return NotFound();
            }
            return await _WebApiDbContext.Items.ToListAsync();
        }

        // GET: api/Items/5
        //[HttpGet("{username}")]
        //public async Task<ActionResult<Item>> GetItem(string username) {
        //    if (_WebApiDbContext.Items == null) {
        //        return NotFound();
        //    }
        //    try {
        //        var Item = await _WebApiDbContext.Items.FindAsync(username);
        //        if (Item == null) {
        //            return NotFound();
        //        }

        //        return Item;
        //    }
        //    catch (Exception ex) {
        //        _ = ex.Message;
        //        return NotFound();
        //    }


        //}

        // POST: api/Items
        //[HttpPost]
        //public async Task<ActionResult<Item>> PostItem(Item Item) {
        //    _WebApiDbContext.Items.Add(Item);
        //    await _WebApiDbContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetItem), new { username = Item.UserName }, Item);
        //}

        // PUT: api/Items/5
        //[HttpPut("{username}")]
        //public async Task<IActionResult> PutItem(string username, Item Item) {
        //    if (username != Item.UserName) {
        //        return BadRequest();
        //    }

        //    _WebApiDbContext.Entry(Item).State = EntityState.Modified;

        //    try {
        //        await _WebApiDbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException) {
        //        if (!ItemExists(username)) {
        //            return NotFound();
        //        }
        //        else {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: api/Items/5
        //[HttpDelete("{username}")]
        //public async Task<IActionResult> DeleteItem(string username) {
        //    if (_WebApiDbContext.Items == null) {
        //        return NotFound();
        //    }

        //    var Item = await _WebApiDbContext.Items.FindAsync(username);
        //    if (Item == null) {
        //        return NotFound();
        //    }

        //    _WebApiDbContext.Items.Remove(Item);
        //    await _WebApiDbContext.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ItemExists(string username) {
        //    return (_WebApiDbContext.Items?.Any(e => e.UserName == username)).GetValueOrDefault();
        //}
    }
}
