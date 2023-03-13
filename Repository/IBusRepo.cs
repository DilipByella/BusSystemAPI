using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IBusRepo
    {
        public string SaveBus(Bus bus);
        public string UpdateBus(Bus bus);
        public string DeleteBus(int BusId);
        Bus GetBus(int BusId);
        List<Bus> GetAllBuses();
        public IEnumerable<SearchBusModel> GetBuses2(string ArrivalStation, string DepartureStation, DateTime date);
    }
}