
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
    public class ContiCCController : ControllerBase
    {
        private readonly IContiCCManager ContiCCMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public ContiCCController(IContiCCManager ContiCCManager, IWebHostEnvironment hostingEnvironment)
        {
            ContiCCMngr = ContiCCManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<ContoCC>> Get()
        {
            return await Task.FromResult(ContiCCMngr.GetContiCC());
        }


        [HttpGet("{*idContoCC}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string idContoCC)
        {

            ContoCC rk = ContiCCMngr.GetContoCC(idContoCC);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(ContoCC rk)
        {
            try
            {
                string rc = ContiCCMngr.AddContoCC(rk);

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

        [HttpPut("{*IdContoCC}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IdContoCC, ContoCC rk)
        {
            try
            {
                string rc = ContiCCMngr.UpdateContoCC(IdContoCC, rk);

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




        [HttpDelete("{*IdContoCC}")]
        [Authorize(Roles = "Administrator,User")]
        public ContoCC Delete(string IdContoCC)
        {
            try
            {
                ContoCC rk = ContiCCMngr.DeleteContoCC(IdContoCC);

                return rk;

            }
            catch (Exception ex) {
                return new ContoCC { Descrizione = "KO" };
            }
        }



    }
}