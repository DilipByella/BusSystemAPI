using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class TicketModel
    {
        public int BookingId { get; set; }

        public int? BusId { get; set; }

        public int? PassengerId { get; set; }

        public double fare { get; set; }
        public string Status { get; set; }

        public int SeatNum { get; set; }
        public string PName { get; set; }

        public int Age { get; set; }

        public string gender { get; set; }

        public string Class { get; set; }

        public string Name { get; set; }


        public string ArrivalTime { get; set; }


        public string DepartureTime { get; set; }


        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }


    }
}

