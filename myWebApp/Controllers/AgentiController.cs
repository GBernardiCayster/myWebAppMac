
using myWebApp.Shared.Models;
using myWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoldReports.Writer;
using BoldReports.Web;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using myWebApp.Interfaces;
using System.Globalization;
using System.Net.Http.Headers;


namespace myWebApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AgentiController : ControllerBase
    {
        private readonly IAgentiManager AgentiMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public AgentiController(IAgentiManager AgentiManager, IWebHostEnvironment hostingEnvironment)
        {
            AgentiMngr = AgentiManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<Agente>> Get()
        {
            return await Task.FromResult(AgentiMngr.GetAgenti());
        }


        [HttpGet("{*idagente}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string idagente)
        {

            Agente rk = AgentiMngr.GetAgente(idagente);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(Agente rk)
        {
            try
            {
                string rc = AgentiMngr.AddAgente(rk);

                if (rc == "OK")
                {
                    return Ok();
                }
                else
                {
                    if (rc == "NOTFOUND")
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{*IdAgente}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IdAgente, Agente rk)
        {
            try
            {
                string rc = AgentiMngr.UpdateAgente(IdAgente, rk);

                if (rc == "OK")
                {
                    return Ok();
                }
                else
                {
                    if (rc == "NOTFOUND")
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        [HttpDelete("{*IdAgente}")]
        [Authorize(Roles = "Administrator,User")]
        public Agente Delete(string IdAgente)
        {
            try
            {
                Agente rk = AgentiMngr.DeleteAgente(IdAgente);

                return rk;

            }
            catch (Exception ex)
            {
                return new Agente { RagioneSociale = "KO" };
            }
        }

        [HttpGet("GetListReport/{writerFormat}")]
        public async Task<String> GetListReport(string writerFormat)
        {

            //DataSource List of Agenti
            List<Agente> Agenti = await Task.FromResult(AgentiMngr.GetAgenti());


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
                fileName = "Agenti.pdf";
                type = "pdf";
                format = WriterFormat.PDF;
            }
            else if (writerFormat == "Word")
            {
                fileName = "Agenti.doc";
                type = "doc";
                format = WriterFormat.Word;
            }
            else if (writerFormat == "CSV")
            {
                fileName = "Agenti.csv";
                type = "csv";
                format = WriterFormat.CSV;
            }
            else
            {
                fileName = "Agenti.xls";
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


    }
}