
using myWebApp.Shared.Models;
using myWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace myWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentiController : ControllerBase
    {
        private readonly mySQLDbContext _WebApIDAgentebContext;

        public AgentiController(mySQLDbContext WebApIDAgentebContext)
        {
            _WebApIDAgentebContext = WebApIDAgentebContext;
            _WebApIDAgentebContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        // GET: api/Agenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgenti()
        {
            if (_WebApIDAgentebContext.Agenti == null)
            {
                return NotFound();
            }
            return await _WebApIDAgentebContext.Agenti.ToListAsync();
        }

        // GET: api/Agenti/5
        [HttpGet("{IDAgente}")]
        public async Task<ActionResult<Agente>> GetAgente(int IDAgente)
        {
            if (_WebApIDAgentebContext.Agenti == null)
            {
                return NotFound();
            }
            try
            {
                var Agente = await _WebApIDAgentebContext.Agenti.FindAsync(IDAgente);
                if (Agente == null)
                {
                    return NotFound();
                }

                return Agente;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return NotFound();
            }


        }

        // POST: api/Agenti      Add Agente
        [HttpPost]
        public async Task<ActionResult<Agente>> PostAgente(Agente Agente)
        {
            if (!AgenteExists(Agente.IDAgente))
            {
                try
                {
                    _WebApIDAgentebContext.Agenti.Add(Agente);
                    await _WebApIDAgentebContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                    return BadRequest();
                }
            }


            return CreatedAtAction(nameof(GetAgente), new { IDAgente = Agente.IDAgente }, Agente);
        }

        // PUT: api/Agenti/5     //Update
        [HttpPut("{IDAgente}")]
        public async Task<IActionResult> PutAgente(string IDAgente, Agente Agente)
        {
            if (IDAgente != Agente.IDAgente)
            {
                return BadRequest();
            }

            _WebApIDAgentebContext.Entry(Agente).State = EntityState.Modified;

            try
            {
                await _WebApIDAgentebContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenteExists(IDAgente))
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

        // DELETE: api/Agenti/5
        [HttpDelete("{IDAgente}")]
        public async Task<IActionResult> DeleteAgente(string IDAgente)
        {
            if (_WebApIDAgentebContext.Agenti == null)
            {
                return NotFound();
            }

            var Agente = await _WebApIDAgentebContext.Agenti.FindAsync(IDAgente);
            if (Agente == null)
            {
                return NotFound();
            }

            _WebApIDAgentebContext.Agenti.Remove(Agente);
            await _WebApIDAgentebContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenteExists(string IDAgente)
        {
            return (_WebApIDAgentebContext.Agenti?.Any(a => a.IDAgente == IDAgente)).GetValueOrDefault();
        }
    }
}