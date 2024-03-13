
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
    public class ZoneController : ControllerBase
    {
        private readonly IZoneManager ZoneMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public ZoneController(IZoneManager ZoneManager, IWebHostEnvironment hostingEnvironment)
        {
            ZoneMngr = ZoneManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<Zona>> Get()
        {
            return await Task.FromResult(ZoneMngr.GetZone());
        }


        [HttpGet("{*idZona}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string idZona)
        {

            Zona rk = ZoneMngr.GetZona(idZona);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(Zona rk)
        {
            try
            {
                string rc = ZoneMngr.AddZona(rk);

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

        [HttpPut("{*IdZona}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IdZona, Zona rk)
        {
            try
            {
                string rc = ZoneMngr.UpdateZona(IdZona, rk);

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




        [HttpDelete("{*IdZona}")]
        [Authorize(Roles = "Administrator,User")]
        public Zona Delete(string IdZona)
        {
            try
            {
                Zona rk = ZoneMngr.DeleteZona(IdZona);

                return rk;

            }
            catch (Exception ex)
            {
                return new Zona { Descrizione = "KO" };
            }
        }



    }
}