
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
    public class ClientiController : ControllerBase
    {
        private readonly IClientiManager ClientiMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public ClientiController(IClientiManager ClientiManager, IWebHostEnvironment hostingEnvironment)
        {
            ClientiMngr = ClientiManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<Cliente>> Get()
        {
            return await Task.FromResult(ClientiMngr.GetClienti());
        }


        [HttpGet("{*idCliente}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string idCliente)
        {

            Cliente rk = ClientiMngr.GetCliente(idCliente);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(Cliente rk)
        {
            try
            {
                string rc = ClientiMngr.AddCliente(rk);

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

        [HttpPut("{*IdCliente}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IdCliente, Cliente rk)
        {
            try
            {
                string rc = ClientiMngr.UpdateCliente(IdCliente, rk);

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




        [HttpDelete("{*IdCliente}")]
        [Authorize(Roles = "Administrator,User")]
        public Cliente Delete(string IdCliente)
        {
            try
            {
                Cliente rk = ClientiMngr.DeleteCliente(IdCliente);

                return rk;

            }
            catch (Exception ex)
            {
                return new Cliente { RagioneSociale = "KO" };
            }
        }

        [HttpGet("GetListReport/{writerFormat}")]
        public async Task<String> GetListReport(string writerFormat)
        {

            //DataSource List of Clienti
            List<Cliente> Clienti = await Task.FromResult(ClientiMngr.GetClienti());


            // Here, we have loaded the Clienti report from application the folder wwwroot\Resources.
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"/Resources/Clienti.rdl", FileMode.Open, FileAccess.Read);
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
            ds.Name = "Clienti";
            ds.Value = Clienti;

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