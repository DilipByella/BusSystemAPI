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
    public class BookingController : ControllerBase
    {
        private BookingServices _bookingS;
        public BookingController(BookingServices bookingS)
        {
            _bookingS = bookingS;
        }
        [HttpPost("SaveBooking")]
        public IActionResult SaveBooking(Booking Booking)
        {
            return Ok(_bookingS.SaveBooking(Booking));
        }
        [HttpDelete("DeleteBooking")]
        public IActionResult DeactBooking(int BookingId, int BusId)
        {
            return Ok(_bookingS.DeactBooking(BookingId, BusId));
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking Booking)
        {
            return Ok(_bookingS.UpdateBooking(Booking));
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int BookingId)
        {
            return Ok(_bookingS.GetBooking(BookingId));
        }

        [HttpGet("GetAllBookings")]
        public List<Booking> GetAllBookings()
        {
            return _bookingS.GetAllBookings();
        }
        [HttpGet("CalculateFare")]
        public IActionResult CalculateFare(int BusId, string Class, int PassengerId, int UserId)
        {
            return Ok(_bookingS.CalculateFare(BusId, Class, PassengerId, UserId));
        }
        [HttpGet("ConfirmBooking")]
        public IActionResult ConfirmBooking(int BookingId)
        {
            return Ok(_bookingS.ConfirmBooking(BookingId));
        }
        [HttpGet("GetBookingHistory")]
        public IActionResult GetBookingByUserID(int UserId)
        {
            return Ok(_bookingS.GetBookingByUserID(UserId));
        }
        [HttpGet("GetBookingId")]
        public IActionResult GetBookingId(int PassengerId)
        {
            return Ok(_bookingS.GetBookingId(PassengerId));
        }
    }
}