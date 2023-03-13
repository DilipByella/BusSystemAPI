using BusSystem.API.Model;
using BusSystem.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCredController : ControllerBase
    {
        private BankCredServices _bankcredServices;
        public BankCredController(BankCredServices bankcredServices)
        {
            _bankcredServices = bankcredServices;
        }
        [HttpPost("SaveBankCred")]
        public IActionResult SaveBankCred(BankCred bankcred)
        {
            return Ok(_bankcredServices.SaveBankCred(bankcred));
        }
        [HttpPut("UpdateBankCred")]
        public IActionResult Updatebankcred(BankCred bankcred)
        {
            return Ok(_bankcredServices.UpdateBankCred(bankcred));
        }
        [HttpDelete("DeactBankCred")]
        public IActionResult Deactbankcred(int Bankcred)
        {
            return Ok(_bankcredServices.DeactBankCred(Bankcred));
        }
        [HttpGet("GetBankCred")]
        public IActionResult Getbankcred(int BankCredId)
        {
            return Ok(_bankcredServices.GetBankCred(BankCredId));
        }
        [HttpGet("GetAllbankcreds()")]
        public List<BankCred> GetAllbankcreds()
        {
            return _bankcredServices.GetAllBankCreds();
        }
    }
}