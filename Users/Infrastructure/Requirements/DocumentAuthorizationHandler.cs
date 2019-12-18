using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Infrastructure.Requirements
{
    public class DocumentAuthorizationHandler : AuthorizationHandler<DocumentAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentAuthorizationRequirement requirement)
        {
            ProtectedDocument document = context.Resource as ProtectedDocument;
            string userName = context.User?.Identity?.Name;

            if(
                document != null
                && userName != null
                && (
                    (requirement.AllowAuthors && (document.Author?.Equals(userName, StringComparison.OrdinalIgnoreCase) ?? false))
                    || (requirement.AllowEditors && (document.Editor?.Equals(userName, StringComparison.OrdinalIgnoreCase) ?? false))
                    )
                )
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
