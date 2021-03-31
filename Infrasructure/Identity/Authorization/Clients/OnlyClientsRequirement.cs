using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrasructure.Identity.Authorization.Clients
{
    public class OnlyClientsRequirement : IAuthorizationRequirement
    {
    }
}
