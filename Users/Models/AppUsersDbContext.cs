using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        public static async Task CreateDefaultAdminUser(IApplicationBuilder app, IConfiguration config)
        {
            UserManager<AppUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            IdentityRole adminRole = await roleManager.FindByNameAsync(config["Data:DefaultAdminUser:Role"]);
            if (adminRole != null)
            {
                if ((await userManager.GetUsersInRoleAsync(config["Data:DefaultAdminUser:Role"])).Count > 0)
                    return;
            }
            else
            {
                await roleManager.CreateAsync(new IdentityRole(config["Data:DefaultAdminUser:Role"]));
            }

            AppUser adminUser = new AppUser
            {
                UserName = config["Data:DefaultAdminUser:Name"],
                Email = config["Data:DefaultAdminUser:Email"],
            };
            
            IdentityResult result = await userManager.CreateAsync(adminUser, config["Data:DefaultAdminUser:Password"]);
            if(result.Succeeded)
                await userManager.AddToRoleAsync(adminUser, config["Data:DefaultAdminUser:Role"]);
        }

    }
}
