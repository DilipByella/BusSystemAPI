using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int TransactionId { get; set; }
        [ForeignKey("BookingId")]
        public int? BookingId { get; set; }


        [Required(ErrorMessage = "The email cannot be empty.")]
        [Column(TypeName = "decimal(18,4)")]
        public double Fare { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "The bus status cannot be empty.")]
        public string TransactionStatus { get; set; }
        public ICollection<Tickets> tickets { get; set; }
    }
}