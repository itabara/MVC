﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI_Validation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // register filters
            config.Filters.Add(new ValidationRepositoryFilter.ValidationErrorHandlerFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();            
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
