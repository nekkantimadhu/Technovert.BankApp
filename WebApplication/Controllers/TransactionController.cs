using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Repositories;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction transactionServices;

        public TransactionController(ITransaction transactionServices)
        {
            this.transactionServices = transactionServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetTransactions()
        {
            try
            {
                return Ok(await transactionServices.GetTransactions());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(string id)
        {
            try
            {
                var result = await transactionServices.GetTransaction(id);
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

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest();
                }
                var newTransaction = await transactionServices.AddTransaction(transaction);
                return CreatedAtAction(nameof(GetTransaction), new { id = newTransaction.TransId }, newTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Retrieval Error");
            }

        }
    }
}