using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Net;

namespace WebAPI_Versioning_CustomerHeaders.Controllers
{
    public class CustomHeaderControllerSelector : DefaultHttpControllerSelector
    {
        public CustomHeaderControllerSelector(HttpConfiguration cfg) : base(cfg) { }

        public override string GetControllerName(System.Net.Http.HttpRequestMessage request)
        {
            string controllerName = base.GetControllerName(request);
            int controllerVersion;
            if (request.Headers.Contains("X-Version"))
            {
                string headerValue = request.Headers.GetValues("X-Version").First();
                if (headerValue == "0")
                {
                    return controllerName;
                }

                if (!String.IsNullOrEmpty(headerValue) && Int32.TryParse(headerValue, out controllerVersion))
                {
                    controllerName = String.Format("{0}v{1}", controllerName, controllerVersion);
                    HttpControllerDescriptor controllerDescr = null;
                    if (!this.GetControllerMapping().TryGetValue(controllerName, out controllerDescr))
                    {
                        string message = "No HTTP resource was found for specified request URI {0} and version {1}";
                        throw new HttpResponseException(request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format(message, request.RequestUri, controllerVersion)));
                    }
                }
            }
            return controllerName;
        }
    }
}