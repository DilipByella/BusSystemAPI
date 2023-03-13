using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusSystem.API.Model;
using BusSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionServices _transactionServices;
        public TransactionController(TransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }
        [HttpPost("SaveTransaction")]
        public IActionResult SaveTransaction(Transaction transaction)
        {
            return Ok(_transactionServices.SaveTransaction(transaction));
        }
        [HttpPut("UpdateTransaction")]
        public IActionResult UpdateTransaction(Transaction transaction)
        {
            return Ok(_transactionServices.UpdateTransaction(transaction));
        }
        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction(int TransactionId)
        {
            return Ok(_transactionServices.GetTransaction(TransactionId));
        }
        [HttpGet("GetAllTransaction()")]
        public List<Transaction> GetAllTransaction()
        {
            return _transactionServices.GetAllTransaction();
        }
    }
}