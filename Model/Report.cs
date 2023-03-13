using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class Report
    {
        public int PassengerId { get; set; }
        public string PName { get; set; }
        public int Age { get; set; }
        public string gender { get; set; }
        public string Class { get; set; }
        public int BookingId { get; set; }
        public double fare { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int SeatNum { get; set; }
    }
}
