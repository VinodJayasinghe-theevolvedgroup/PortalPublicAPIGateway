using Infrasructure.Identity.Authorization.Common;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrasructure.Identity.Authorization.SubClients
{
    public class OnlySubClientsAuthorizationHandler : AuthorizationHandler<OnlySubClientsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlySubClientsRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Manager))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
