using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WEBAPI_Exception.CustomFilterRepo
{
    public class ProcessExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Check the Exception Type
            if (actionExecutedContext.Exception is ProcessException)
            {
                // the response message set by the Action during execution
                var res = actionExecutedContext.Exception.Message;

                // Define the Response message
                HttpResponseMessage respone = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(res),
                    ReasonPhrase = res
                };
                actionExecutedContext.Response = respone;
            }
        }
    }
}