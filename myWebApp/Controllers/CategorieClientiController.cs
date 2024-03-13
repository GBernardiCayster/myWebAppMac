
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
    public class CategorieClientiController : ControllerBase
    {
        private readonly ICategorieClientiManager CategorieClientiMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public CategorieClientiController(ICategorieClientiManager CategorieClientiManager, IWebHostEnvironment hostingEnvironment)
        {
            CategorieClientiMngr = CategorieClientiManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<CategoriaClienti>> Get()
        {
            return await Task.FromResult(CategorieClientiMngr.GetCategorieClienti());
        }


        [HttpGet("{*IDCategoria}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string IDCategoria)
        {

            CategoriaClienti rk = CategorieClientiMngr.GetCategoriaClienti(IDCategoria);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(CategoriaClienti rk)
        {
            try
            {
                string rc = CategorieClientiMngr.AddCategoriaClienti(rk);

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

        [HttpPut("{*IDCategoria}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IDCategoria, CategoriaClienti rk)
        {
            try
            {
                string rc = CategorieClientiMngr.UpdateCategoriaClienti(IDCategoria, rk);

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




        [HttpDelete("{*IDCategoria}")]
        [Authorize(Roles = "Administrator,User")]
        public CategoriaClienti Delete(string IDCategoria)
        {
            try
            {
                CategoriaClienti rk = CategorieClientiMngr.DeleteCategoriaClienti(IDCategoria);

                return rk;

            }
            catch (Exception ex)
            {
                return new CategoriaClienti { Descrizione = "KO" };
            }
        }



    }
}