using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IPassengerRepo
    {
        public Passenger UpdatePassenger(int PassengerId, Passenger passenger);
        public Passenger AddPassenger(Passenger passenger);
        public string DeletePassenger(int PassengerId);
        public Passenger GetPassenger(int PassengerId);
        public List<Passenger> GetAllPassengers();
        public IEnumerable<Report> GetReport(int BusId);
        public IEnumerable<Report> GetReportStat(int BusId, string Status);
    }
}
