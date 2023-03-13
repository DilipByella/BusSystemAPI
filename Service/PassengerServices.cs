using BusSystem.API.Model;
using BusSystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Services
{
    public class PassengerServices
    {
        private IPassengerRepo passenger;
        public PassengerServices(IPassengerRepo _passenger)
        {
            passenger = _passenger;
        }
        public Passenger AddPassenger(Passenger Passenger)
        {
            return passenger.AddPassenger(Passenger);
        }
        public string DeletePassenger(int PassengerId)
        {
            return passenger.DeletePassenger(PassengerId);
        }
        public Passenger UpdatePassenger(int PassengerId, Passenger Passenger)
        {
            return passenger.UpdatePassenger(PassengerId, Passenger);
        }
        public Passenger GetPassenger(int PassengerId)
        {
            return passenger.GetPassenger(PassengerId);
        }
        public List<Passenger> GetAllPassengers()
        {
            return passenger.GetAllPassengers();
        }
        public IEnumerable<Report> GetReport(int BusId)
        {
            return passenger.GetReport(BusId);
        }
        public IEnumerable<Report> GetReportStat(int BusId, string Status)
        {
            return passenger.GetReportStat(BusId, Status);
        }
    }
}