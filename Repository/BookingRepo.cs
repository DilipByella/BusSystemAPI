using BusSystem.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private BusDbContext _busDb;
        public BookingRepo(BusDbContext busDb)
        {
            _busDb = busDb;
        }

        #region DeactivateBookinh

        public string DeactBooking(int BookingId, int BusId)
        {
            string Result = string.Empty;
            Booking delete = null;

            try
            {
                Seat seat = _busDb.seat.FirstOrDefault(q => q.BusId == BusId);
                delete = _busDb.bookings.Find(BookingId);
                if (delete != null && delete.Status != "CANCELLED")
                {

                    delete.Status = "CANCELLED";
                    if (delete.Classes == "FirstAC")
                    {
                        seat.FirstAC++;
                        seat.Total++;
                    }
                    if (delete.Classes == "SecondAC")
                    {
                        seat.SecondAC++;
                        seat.Total++;
                    }
                    if (delete.Classes == "Sleeper")
                    {
                        seat.Sleeper++;
                        seat.Total++;
                    }

                    _busDb.SaveChanges();
                    Result = "200";
                }


            }
            catch (Exception ex)
            {
                Result = "400";
            }
            return Result;

        }

        #endregion


        #region GetAllBookings

        public List<Booking> GetAllBookings()
        {
            string Result = string.Empty;
            List<Booking> bookings = null;
            try
            {
                bookings = _busDb.bookings.ToList();

            }
            catch (Exception ex)
            {

            }
            return bookings;
        }

        #endregion


        #region GetBooking

        public Booking GetBooking(int BookingId)
        {
            Booking booking = null;
            try
            {
                booking = _busDb.bookings.Find(BookingId);
            }
            catch (Exception ex)
            {

            }
            return booking;
        }

        #endregion


        #region SaveBooking

        public string SaveBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _busDb.bookings.Add(booking);
                _busDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

        #endregion


        #region UpdateBooking

        public string UpdateBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _busDb.Entry(booking).State = EntityState.Modified;
                _busDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

        #endregion


        #region CalculateFare

        public double CalculateFare(int BusId, string Class, int PassengerId, int UserId)
        {
            double fare = 0.00;
            var bus = _busDb.buses.Find(BusId);
            int distance = (int)bus.distance;
            Seat seat = _busDb.seat.FirstOrDefault(q => q.BusId == BusId);
            if (Class == "FirstAC")
            {
                fare = ((8 * distance) + 250 + 70) * 0.18;
                seat.FirstAC = seat.FirstAC - 1;
                seat.Total = seat.Total - 1;
            }
            if (Class == "SecondAC")
            {
                fare = ((6 * distance) + 150 + 50) * 0.18;
                seat.SecondAC = seat.SecondAC - 1;
                seat.Total = seat.Total - 1;
            }
            if (Class == "Sleeper")
            {
                fare = ((4 * distance) + 50 + 30) * 0.18;
                seat.Sleeper = seat.Sleeper - 1;
                seat.Total = seat.Total - 1;
            }
            Random rnd = new Random();
            int seatNum = rnd.Next(1, 72);
            _busDb.bookings.Add(new Booking { BusId = BusId, Classes = Class, Status = "Pending", Date = DateTime.Now, PassengerId = PassengerId, SeatNum = seatNum, fare = fare, UserId = UserId });
            _busDb.Entry(seat).State = EntityState.Modified;//to reduce seat
            _busDb.SaveChanges();
            return fare;
        }

        #endregion


        #region ConfirmBooking
        public Booking ConfirmBooking(int BookingId)
        {
            string Result = string.Empty;
            Booking confirm = null;

            try
            {
                confirm = _busDb.bookings.Find(BookingId);
                if (confirm != null)
                {
                    confirm.Status = "CONFIRM";
                    _busDb.transaction.Add(new Transaction { BookingId = BookingId, TransactionStatus = "Success", Fare = confirm.fare });
                    _busDb.SaveChanges();
                    Result = "200";
                }

            }
            catch (Exception ex)
            {
                Result = "400";
            }
            return confirm;

        }
        #endregion


        #region GetBookingbyUserID
        public IEnumerable<Booking> GetBookingByUserID(int UserId)
        {
            var booking = _busDb.bookings.Where(a => a.UserId == UserId).ToList();

            return booking;
        }
        #endregion


        #region GetBookingID

        public int GetBookingId(int PassengerId)
        {
            Booking booking = _busDb.bookings.FirstOrDefault(q => q.PassengerId == PassengerId);
            int BookingId = booking.BookingId;
            return BookingId;

        }

        #endregion


    }
}