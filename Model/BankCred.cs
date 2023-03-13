using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class BankCred
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int BankCredId { get; set; }

        [Required(ErrorMessage = "Enter the User ID")]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "The Bank name cannot be empty.")]
        public string BankName { get; set; }

        [MinLength(4, ErrorMessage = "Atleast 4 digits")]
        [MaxLength(11, ErrorMessage = "Atleast 11 digits")]
        [Required(ErrorMessage = "Enter the last four digits of you card number.")]
        public string CardNumber { get; set; }


        public bool isActive { get; set; }
    }
}