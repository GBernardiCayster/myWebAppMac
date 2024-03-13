
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
    public class TestateListiniController : ControllerBase
    {
        private readonly ITestateListiniManager TestateListiniMngr;
        private IWebHostEnvironment _hostingEnvironment;

        public TestateListiniController(ITestateListiniManager TestateListiniManager, IWebHostEnvironment hostingEnvironment)
        {
            TestateListiniMngr = TestateListiniManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<TestataListino>> Get()
        {
            return await Task.FromResult(TestateListiniMngr.GetTestateListini());
        }


        [HttpGet("{*IDListino}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Get(string IDListino)
        {

            TestataListino rk = TestateListiniMngr.GetTestataListino(IDListino);
            if (rk != null)
            {
                return Ok(rk);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Post(TestataListino rk)
        {
            try
            {
                string rc = TestateListiniMngr.AddTestataListino(rk);

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

        [HttpPut("{*IDListino}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Put(string IDListino, TestataListino rk)
        {
            try
            {
                string rc = TestateListiniMngr.UpdateTestataListino(IDListino, rk);

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




        [HttpDelete("{*IDListino}")]
        [Authorize(Roles = "Administrator,User")]
        public TestataListino Delete(string IDListino)
        {
            try
            {
                TestataListino rk = TestateListiniMngr.DeleteTestataListino(IDListino);

                return rk;

            }
            catch (Exception ex)
            {
                return new TestataListino { Descrizione = "KO" };
            }
        }



    }
}