using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }

        public int UserId { get; set; }

        public string PName { get; set; }

        public int Age { get; set; }

        public string gender { get; set; }

        public string Class { get; set; }

    }
}