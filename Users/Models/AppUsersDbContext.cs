using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class AppUsersDbContext : IdentityDbContext<AppUser>
    {
        public AppUsersDbContext(DbContextOptions<AppUsersDbContext> options)
            : base(options)
        {}

    }
}
