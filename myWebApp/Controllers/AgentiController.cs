
using myWebApp.Shared.Models;
using myWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoldReports.Writer;
using BoldReports.Web;
using Microsoft.AspNetCore.Diagnostics;


namespace myWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentiController : ControllerBase
    {
        private readonly mySQLDbContext _WebAppDbContext;
        private IWebHostEnvironment _hostingEnvironment;

        public AgentiController(mySQLDbContext WebApIDAgentebContext,  IWebHostEnvironment hostingEnvironment)
        {
            _WebAppDbContext = WebApIDAgentebContext;
            _hostingEnvironment = hostingEnvironment;
            _WebAppDbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        // GET: api/Agenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgenti()
        {
            if (_WebAppDbContext.Agenti == null)
            {
                return NotFound();
            }
            return await _WebAppDbContext.Agenti.ToListAsync();
        }

        // GET: api/Agenti/5
        [HttpGet("{IDAgente}")]
        public async Task<ActionResult<Agente>> GetAgente(int IDAgente)
        {
            if (_WebAppDbContext.Agenti == null)
            {
                return NotFound();
            }
            try
            {
                var Agente = await _WebAppDbContext.Agenti.FindAsync(IDAgente);
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


        [HttpGet("GetListReport/{writerFormat}")]
        public async Task<String> GetListReport(string writerFormat)
        {

            //DataSource List of Agenti
            List<Agente> Agenti = await _WebAppDbContext.Agenti.OrderBy(a => a.RagioneSociale).ToListAsync();


            // Here, we have loaded the Agenti report from application the folder wwwroot\Resources.
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"/Resources/Agenti.rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            ReportWriter writer = new ReportWriter();

            string? fileName = null;
            WriterFormat format;
            string? type = null;

            if (writerFormat == "PDF")
            {
                fileName = "Clienti.pdf";
                type = "pdf";
                format = WriterFormat.PDF;
            }
            else if (writerFormat == "Word")
            {
                fileName = "Clienti.doc";
                type = "doc";
                format = WriterFormat.Word;
            }
            else if (writerFormat == "CSV")
            {
                fileName = "Clienti.csv";
                type = "csv";
                format = WriterFormat.CSV;
            }
            else
            {
                fileName = "Clienti.xls";
                type = "xls";
                format = WriterFormat.Excel;
            }

            writer.LoadReport(reportStream);

            ReportDataSource ds = new ReportDataSource();
            ds.Name = "Agenti";
            ds.Value = Agenti;

            writer.DataSources.Add(ds);

            MemoryStream memoryStream = new MemoryStream();
            writer.Save(memoryStream, format);

            // Download the generated export document to the client side.
            memoryStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/" + type);
            fileStreamResult.FileDownloadName = fileName;


            //return fileStreamResult;

            byte[] retValue = memoryStream.ToArray();

            string strValue = Convert.ToBase64String(retValue);

            return strValue;
        }

        // POST: api/Agenti      Add Agente
        [HttpPost]
        public async Task<ActionResult<Agente>> PostAgente(Agente Agente)
        {
            if (!AgenteExists(Agente.IDAgente))
            {
                try
                {
                    _WebAppDbContext.Agenti.Add(Agente);
                    await _WebAppDbContext.SaveChangesAsync();
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

            _WebAppDbContext.Entry(Agente).State = EntityState.Modified;

            try
            {
                await _WebAppDbContext.SaveChangesAsync();
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
            if (_WebAppDbContext.Agenti == null)
            {
                return NotFound();
            }

            var Agente = await _WebAppDbContext.Agenti.FindAsync(IDAgente);
            if (Agente == null)
            {
                return NotFound();
            }

            try
            {
                _WebAppDbContext.Agenti.Remove(Agente);
                await _WebAppDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) {
                var exceptionHandlerFeature =
                        HttpContext.Features.Get<IExceptionHandlerFeature>()!;

                return Problem(
                    detail: exceptionHandlerFeature.Error.StackTrace,
                    title: exceptionHandlerFeature.Error.Message);
            }

            return NoContent();
        }

        private bool AgenteExists(string IDAgente)
        {
            return (_WebAppDbContext.Agenti?.Any(a => a.IDAgente == IDAgente)).GetValueOrDefault();
        }
    }
}