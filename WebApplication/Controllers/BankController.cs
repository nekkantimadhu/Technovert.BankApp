using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BanksController : ControllerBase
        {
            private readonly IBank bankServices;

            public BanksController(IBank bankServices)
            {
                this.bankServices = bankServices;
            }

            [HttpGet]
            public async Task<ActionResult> GetBanks()
            {
                try
                {
                    return Ok(await bankServices.GetBanks());
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
                }
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Bank>> GetBank(string id)
            {
                try
                {
                    var result = await bankServices.GetBank(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return result;
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
                }
            }

        }
    }
}