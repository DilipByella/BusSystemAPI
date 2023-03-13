using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class BusRepo : IBusRepo
    {
        private BusDbContext _busDb;
        public BusRepo(BusDbContext busDbContext)
        {
            _busDb = busDbContext;
        }
        #region DeleteBus
        /// <summary>
        /// Deactivates the Bus when this fuction is invoked
        /// </summary>
        /// <param name="BusId"></param>
        /// <returns>If the BusId is present then isActive is changed to false</returns>
        public string DeleteBus(int BusId)
        {

            string Result = string.Empty;
            Bus delete;

            try
            {
                delete = _busDb.buses.Find(BusId);

                if (delete != null)
                {
                    //_busDb.busesDb.Remove(delete);
                    delete.isActive = false;
                    _busDb.SaveChanges();
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
        #endregion

        #region GetAllBuses
        /// <summary>
        /// When the function is invoked we get the list of all Buses 
        /// </summary>
        /// <returns>List of bus</returns>
        public List<Bus> GetAllBuses()
        {
            string Result = string.Empty;
            List<Bus> buses = null;
            try
            {
                buses = _busDb.buses.ToList();
                return buses;

            }
            catch (Exception ex)
            {

            }
            return buses;
        }
        #endregion

        #region GetBus
        /// <summary>
        /// When this function is invocked we get the buses by Id
        /// </summary>
        /// <param name="BusId"></param>
        /// <returns>Finds the Id of the Bus</returns>
        public Bus GetBus(int BusId)
        {
            Bus bus = null;
            try
            {
                bus = _busDb.buses.Find(BusId);
            }
            catch (Exception ex)
            {

            }
            return bus;
        }
        #endregion

        #region AddBus
        /// <summary>
        /// When this function is invoked we can Add a bus
        /// </summary>
        /// <param name="bus"></param>
        /// <returns></returns>
        public string SaveBus(Bus bus)
        {
            string stCode = string.Empty;
            try
            {
                _busDb.buses.Add(bus);
                _busDb.SaveChanges();

                stCode = "200";
            }
            catch (Exception ex)
            {
                return ex.Message;
                stCode = "400";
            }
            return stCode;
        }
        #endregion

        #region UpdateBus
        /// <summary>
        /// When this function is invoked we will be able to Update Bus details
        /// </summary>
        /// <param name="bus"></param>
        /// <returns>Updated Bus Details</returns>
        public string UpdateBus(Bus bus)
        {
            string stCode = string.Empty;
            try
            {
                _busDb.Entry(bus).State = EntityState.Modified;
                _busDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;

        }
        #endregion

        #region GetBusList2

        public IEnumerable<SearchBusModel> GetBuses2(string ArrivalStation, string DepartureStation, DateTime date)
        {
            var Result = (from t in _busDb.buses
                          join s in _busDb.seat on t.BusId equals s.BusId
                          select new SearchBusModel
                          {
                              BusId = t.BusId,
                              Name = t.Name,
                              ArrivalTime = t.ArrivalTime,
                              DepartureTime = t.DepartureTime,
                              ArrivalDate = t.ArrivalDate,
                              DepartureDate = t.DepartureDate,
                              DepartureStation = t.DepartureStation,
                              ArrivalStation = t.ArrivalStation,
                              distance = t.distance,
                              FirstAC = s.FirstAC,
                              SecondAC = s.SecondAC,
                              Sleeper = s.Sleeper,
                              Total = s.Total,
                          }).ToList().Where(q => q.ArrivalStation == ArrivalStation && q.DepartureStation == DepartureStation && q.DepartureDate == date);
            return Result;
        }

        #endregion
    }
}