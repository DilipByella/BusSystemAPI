using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class Quota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotaId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string type { get; set; }
        public int Percentage { get; set; }
        public bool isActive { get; set; }
        public ICollection<Booking> _booking { get; set; }
    }
}
