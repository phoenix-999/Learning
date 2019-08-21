using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pleas, enter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please, enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your phone number")]
        [RegularExpression("\\d+", ErrorMessage = "Please, enter valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please, specify whether you'll attend")]
        public bool? WillAttend { get; set; }
    }
}
