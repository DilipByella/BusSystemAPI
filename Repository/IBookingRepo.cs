using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IBookingRepo
    {
        public string SaveBooking(Booking booking);
        public string UpdateBooking(Booking booking);
        public string DeactBooking(int BookingId, int BusId);
        Booking GetBooking(int BookingId);
        List<Booking> GetAllBookings();
        public double CalculateFare(int BusId, string Class, int PassengerId, int UserId);
        public Booking ConfirmBooking(int BookingId);
        public IEnumerable<Booking> GetBookingByUserID(int UserId);
        public int GetBookingId(int PassengerId);
    }
}