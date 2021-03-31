using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrasructure.Identity.Authorization.ThirdParties
{
    public class OnlyThirdPartiesRequirement : IAuthorizationRequirement
    {
    }
}
