using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Infrastructure.Requirements
{
    public class BlockUsersRequirement : IAuthorizationRequirement
    {
        public BlockUsersRequirement(params string[] usersName)
        {
            BlockedUsers = usersName;
        }

        public IEnumerable<string> BlockedUsers { get; }
    }
}
