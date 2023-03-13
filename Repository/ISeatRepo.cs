using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface ISeatRepo
    {
        public string SaveSeat(Seat seat);
        public Seat UpdateSeat(int SeatId, Seat seat);
        Seat GetSeat(int SeatId);
        List<Seat> GetAllSeats();
    }
}