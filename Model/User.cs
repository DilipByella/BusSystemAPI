using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "The bus name cannot be empty.")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "The email cannot be empty.")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "The addressname cannot be empty.")]
        public string Address { get; set; }


        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "Password is Compulsory.")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Role { get; set; }

        public bool IsActive { get; set; }
        public ICollection<BankCred> bankCreds { get; set; }
        public ICollection<Tickets> tickets { get; set; }
    }
}