using BusSystem.API.Model;
using BusSystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Services
{
    public class SeatServices
    {
        private ISeatRepo _seatRepository;
        public SeatServices(ISeatRepo seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public string SaveSeat(Seat Seat)
        {
            return _seatRepository.SaveSeat(Seat);
        }
        public Seat UpdateSeat(int SeatId, Seat seat)
        {
            return _seatRepository.UpdateSeat(SeatId, seat);
        }
        public Seat GetSeat(int SeatId)
        {
            return _seatRepository.GetSeat(SeatId);
        }
        public List<Seat> GetAllSeats()
        {
            return _seatRepository.GetAllSeats();
        }
    }
}