using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class ListRoleUsers : TagHelper
    {
        [HtmlAttributeName("identity-role")]
        public string RoleId { get; set; }

        RoleManager<IdentityRole> roleManager;
        UserManager<AppUser> userManager;

        public ListRoleUsers(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> usersInRole = new List<string>();
            IdentityRole role = await roleManager.FindByIdAsync(RoleId);
            if (role == null)
                return;
            foreach(var user in userManager.Users)
            {
                if (user == null)
                    continue;
                if( await userManager.IsInRoleAsync(user, role.Name))
                {
                    usersInRole.Add(user.UserName);
                }
            }
            output?.Content.Append(usersInRole.Count == 0 ? "No Users" : string.Join(',', usersInRole));
        }
    }
}
