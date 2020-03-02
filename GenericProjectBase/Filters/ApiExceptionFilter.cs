using Core.Exceptions; 
using System;
using System.Net;
using System.Net.Http; 
using System.Web.Http.Filters;

namespace GenericProjectBase.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ApiException)
            {
                var apiException = context.Exception as ApiException;
                context.Response = context.Request.CreateErrorResponse(apiException.HttpStatus, apiException.Message);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, context.Exception.Message);
            }
            else
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.NotFound, AppResources.InvalidRequest);
            }
        }
    }
}
