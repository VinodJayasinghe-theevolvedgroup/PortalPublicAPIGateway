using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrasructure.Identity.Authentication.Interface
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
