using BusSystem.API.Model;
using BusSystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Services
{
    public class BusServices
    {
        private IBusRepo _IBus;
        public BusServices(IBusRepo Ibus)
        {
            _IBus = Ibus;
        }
        public string SaveBus(Bus bus)
        {
            return _IBus.SaveBus(bus);
        }
        public string DeleteBus(int BusId)
        {
            return _IBus.DeleteBus(BusId);
        }
        public string UpdateBus(Bus bus)
        {
            return _IBus.UpdateBus(bus);
        }
        public Bus GetBus(int BusId)
        {
            return _IBus.GetBus(BusId);
        }
        public List<Bus> GetAllBuses()
        {
            return _IBus.GetAllBuses();
        }
        public IEnumerable<SearchBusModel> GetBuses2(string ArrivalStation, string DepartureStation, DateTime date)
        {
            return _IBus.GetBuses2(ArrivalStation, DepartureStation, date);
        }
    }
}