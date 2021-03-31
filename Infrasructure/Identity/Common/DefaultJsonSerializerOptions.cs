using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Infrasructure.Identity.Common
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };
    }
}
