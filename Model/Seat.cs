using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int SeatId { get; set; }


        public int BusId { get; set; }

        [Required(ErrorMessage = "Enter the number of seats for First AC")]
        public int FirstAC { get; set; }

        [Required(ErrorMessage = "Enter the number of seats for Second AC")]
        public int SecondAC { get; set; }

        [Required(ErrorMessage = "Enter the number of seats for Sleeper")]
        public int Sleeper { get; set; }

        [Required(ErrorMessage = "Enter the total number of seats ")]
        public int Total { get; set; }
    }
}
