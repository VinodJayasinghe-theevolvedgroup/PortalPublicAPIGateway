using System;
using System.Collections.Generic;
using System.Text;

namespace Infrasructure.Identity.Authorization.Common
{
    public static class Policies
    {
        public const string OnlyClients = nameof(OnlyClients);
        public const string OnlySubClients = nameof(OnlySubClients);
        public const string OnlyThirdParties = nameof(OnlyThirdParties);
    }
}
