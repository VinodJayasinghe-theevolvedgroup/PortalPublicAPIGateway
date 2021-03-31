using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ExceptionHandler : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ExceptionHandler() { }

        public ExceptionHandler(HttpStatusCode statusCode)
            => StatusCode = statusCode;

        public ExceptionHandler(HttpStatusCode statusCode, string message) : base(message)
            => StatusCode = statusCode;

        public ExceptionHandler(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner)
            => StatusCode = statusCode;
    }
}
