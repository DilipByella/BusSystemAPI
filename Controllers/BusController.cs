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
    public class BusController : ControllerBase
    {
        private BusServices busS;
        public BusController(BusServices _busS)
        {
            busS = _busS;
        }
        [HttpPost("SaveBus")]
        public IActionResult SaveBus(Bus bus)
        {
            return Ok(busS.SaveBus(bus));
        }
        [HttpDelete("DeleteBus")]
        public IActionResult Deletebus(int BusId)
        {
            return Ok(busS.DeleteBus(BusId));
        }
        [HttpPut("UpdateBus")]
        public IActionResult UpdateBus(Bus bus)
        {
            return Ok(busS.UpdateBus(bus));
        }
        [HttpGet("GetBus")]
        public IActionResult GetBus(int BusId)
        {
            return Ok(busS.GetBus(BusId));
        }

        [HttpGet("GetAllBus")]
        public List<Bus> GetAllBuses()
        {
            return busS.GetAllBuses();
        }
        [HttpGet("SearchBusSeat2")]
        public IEnumerable<SearchBusModel> GetBuses2(string ArrivalStation, string DepartureStation, DateTime date)
        {
            return busS.GetBuses2(ArrivalStation, DepartureStation, date);
        }
    }
}