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
    public class QuotaController : ControllerBase
    {
        public QuotaServices _quotaS;
        public QuotaController(QuotaServices quotaS)
        {
            _quotaS = quotaS;
        }
        [HttpPost("SaveQuota")]
        public IActionResult SaveQuota(Quota quota)
        {
            return Ok(_quotaS.SaveQuota(quota));
        }
        [HttpPut("UpdateQuota")]
        public IActionResult UpdateQuota(Quota quota)
        {
            return Ok(_quotaS.UpdateQuota(quota));
        }
        [HttpGet("GetQuota")]
        public IActionResult GetQuota(int QuotaId)
        {
            return Ok(_quotaS.GetQuota(QuotaId));
        }

        [HttpGet("GetAllQuotas")]
        public List<Quota> GetAllQuotass()
        {
            return _quotaS.GetAllQuotas();
        }
    }
}