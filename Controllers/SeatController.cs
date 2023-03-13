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
    public class SeatController : ControllerBase
    {
        private SeatServices _seatServices;
        public SeatController(SeatServices seatServices)
        {
            _seatServices = seatServices;
        }
        [HttpPost("SaveSeat")]
        public IActionResult Saveseat(Seat seat)
        {
            return Ok(_seatServices.SaveSeat(seat));
        }
        [HttpPut("UpdateSeat")]
        public IActionResult UpdateSeat(int SeatId, Seat seat)
        {
            return Ok(_seatServices.UpdateSeat(SeatId,seat));
        }
        [HttpGet("GetSeat")]
        public IActionResult GetSeat(int SeatId)
        {
            return Ok(_seatServices.GetSeat(SeatId));
        }
        [HttpGet("GetAllSeats()")]
        public List<Seat> GetAllSeats()
        {
            return _seatServices.GetAllSeats();
        }
    }
}