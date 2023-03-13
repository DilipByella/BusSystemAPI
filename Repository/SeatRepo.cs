using BusSystem.API.Model;
using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class SeatRepo : ISeatRepo
    {
        private BusDbContext _busDb;

        public SeatRepo(BusDbContext busDb)
        {
            _busDb = busDb;
        }

        #region GetAllSeats
        public List<Seat> GetAllSeats()
        {
            List<Seat> seat = null;
            try
            {
                seat = _busDb.seat.ToList();

            }
            catch (Exception ex)
            {

            }
            return seat;
        }
        #endregion

        #region GetSeat
        public Seat GetSeat(int SeatId)
        {
            Seat seat = null;
            try
            {
                seat = _busDb.seat.Find(SeatId);
            }
            catch (Exception ex)
            {

            }
            return seat;
        }
        #endregion

        #region SaveSeat
        public string SaveSeat(Seat seat)
        {
            try
            {
                _busDb.seat.Add(seat);
                _busDb.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return "Saved";
        }
        #endregion

        #region UpdateSeat
        #region UpdateSeat
        public Seat UpdateSeat(int SeatId, Seat seat)
        {
            var _seat = _busDb.seat.FirstOrDefault(n => n.SeatId == SeatId);
            try
            {
                if (_seat != null)
                {
                    _seat.FirstAC = seat.FirstAC;
                    _seat.SecondAC = seat.SecondAC;
                    _seat.Sleeper = seat.Sleeper;
                    _seat.Total = seat.Total;

                    _busDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return _seat;
        }
        #endregion
        #endregion
    }
}