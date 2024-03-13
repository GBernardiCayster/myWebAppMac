
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
    public class CondizioniPagamentoController : ControllerBase
    {
        private readonly ICondizioniPagamentoManager CondizioniPagamentoMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public CondizioniPagamentoController(ICondizioniPagamentoManager CondizioniPagamentoManager, IWebHostEnvironment hostingEnvironment)
        {
            CondizioniPagamentoMngr = CondizioniPagamentoManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<CondizionePagamento>> Get()
        {
            return await Task.FromResult(CondizioniPagamentoMngr.GetCondizioniPagamento());
        }


        [HttpGet("{*IDPagamento}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string IDPagamento)
        {

            CondizionePagamento rk = CondizioniPagamentoMngr.GetCondizionePagamento(IDPagamento);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(CondizionePagamento rk)
        {
            try
            {
                string rc = CondizioniPagamentoMngr.AddCondizionePagamento(rk);

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

        [HttpPut("{*IDPagamento}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IDPagamento, CondizionePagamento rk)
        {
            try
            {
                string rc = CondizioniPagamentoMngr.UpdateCondizionePagamento(IDPagamento, rk);

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




        [HttpDelete("{*IDPagamento}")]
        [Authorize(Roles = "Administrator,User")]
        public CondizionePagamento Delete(string IDPagamento)
        {
            try
            {
                CondizionePagamento rk = CondizioniPagamentoMngr.DeleteCondizionePagamento(IDPagamento);

                return rk;

            }
            catch (Exception ex)
            {
                return new CondizionePagamento { Descrizione = "KO" };
            }
        }



    }
}