using Infrasructure.Identity.Authorization.Common;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrasructure.Identity.Authorization.ThirdParties
{
    public class OnlyThirdPartiesAuthorizationHandler : AuthorizationHandler<OnlyThirdPartiesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyThirdPartiesRequirement requirement)
        {
            if (context.User.IsInRole(Roles.ThirdParty))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}