using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public QualificationLevel Qualifications { get; set; }
    }

    public enum Cities
    {
        None,
        London,
        Paris,
        Chicago
    }

    public enum QualificationLevel
    {
        None,
        Basic,
        Advanced
    }
}
