using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProteinStore.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5,ErrorMessage ="Must be at least 5 characters")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8,ErrorMessage ="Must be at least 8 characters")]
        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



    }
}
