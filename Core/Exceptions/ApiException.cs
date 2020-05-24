using System;
using System.Net;

namespace Core.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatus { get; set; }

        public ApiException(string message, HttpStatusCode httpStatus = HttpStatusCode.BadRequest) : base(message)
        {
            HttpStatus = httpStatus;
        }
    }
}
