using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Model
{
    public class LoginModel
    {
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "The email cannot be empty.")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "The password cannot be empty.")]
        public string Password { get; set; }
    }
}
