using BusSystem.API.Model;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class PassengerRepo : IPassengerRepo
    {
        private BusDbContext busDb;
        public PassengerRepo(BusDbContext _busDb)
        {
            busDb = _busDb;
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            string stCode = string.Empty;
            try
            {
                busDb.passenger.Add(passenger);
                busDb.SaveChanges();

                stCode = "200";
            }
            catch (Exception ex)
            {
                //return ex.Message;
                stCode = "400";
            }
            return passenger;
        }

        public string DeletePassenger(int PassengerId)
        {

            string Result = string.Empty;
            Passenger delete;

            try
            {
                delete = busDb.passenger.Find(PassengerId);

                if (delete != null)
                {
                    busDb.passenger.Remove(delete);

                    busDb.SaveChanges();
                    Result = "200";
                }
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            finally
            {
                delete = null;
            }
            return Result;
        }

        public List<Passenger> GetAllPassengers()
        {

            List<Passenger> passenger = null;
            try
            {
                passenger = busDb.passenger.ToList();
                return passenger;

            }
            catch (Exception ex)
            {

            }
            return passenger;
        }

        public Passenger GetPassenger(int PassengerId)
        {
            Passenger passenger = null;
            try
            {
                passenger = busDb.passenger.Find(PassengerId);
                return passenger;
            }
            catch (Exception ex)
            {

            }
            return passenger;
        }

        public Passenger UpdatePassenger(int PassengerId, Passenger passenger)
        {

            var passengers = busDb.passenger.FirstOrDefault(q => q.PassengerId == PassengerId);
            try
            {
                if (passengers != null)
                {
                    passengers.PName = passenger.PName;
                    passengers.Age = passenger.Age;
                    passengers.gender = passenger.gender;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return passengers;
        }

        public IEnumerable<Report> GetReport(int BusId)
        {
            var Result = (from p in busDb.passenger
                          join b in busDb.bookings on p.PassengerId equals b.PassengerId
                          where b.BusId == BusId
                          select new Report
                          {
                              PassengerId = p.PassengerId,
                              PName = p.PName,
                              Age = p.Age,
                              gender = p.gender,
                              Class = p.Class,
                              BookingId = b.BookingId,
                              fare = b.fare,
                              Date = b.Date,
                              Status = b.Status,
                              SeatNum = b.SeatNum
                          }).ToList();
            return Result;
        }

        #region GetReportStat
        public IEnumerable<Report> GetReportStat(int BusId, string Status)
        {
            List<Report> Result;
            if (Status == "All")
            {
                Result = (from p in busDb.passenger
                          join b in busDb.bookings on p.PassengerId equals b.PassengerId
                          where b.BusId == BusId
                          select new Report
                          {
                              PassengerId = p.PassengerId,
                              PName = p.PName,
                              Age = p.Age,
                              gender = p.gender,
                              Class = p.Class,
                              BookingId = b.BookingId,
                              fare = b.fare,
                              Date = b.Date,
                              Status = b.Status,
                              SeatNum = b.SeatNum
                          }).ToList();

            }
            else
            {
                Result = (from p in busDb.passenger
                          join b in busDb.bookings on p.PassengerId equals b.PassengerId
                          where b.BusId == BusId
                          select new Report
                          {
                              PassengerId = p.PassengerId,
                              PName = p.PName,
                              Age = p.Age,
                              gender = p.gender,
                              Class = p.Class,
                              BookingId = b.BookingId,
                              fare = b.fare,
                              Date = b.Date,
                              Status = b.Status,
                              SeatNum = b.SeatNum
                          }).Where(q => q.Status == Status).ToList();

            }
            return Result;
        }
        #endregion
    }
}