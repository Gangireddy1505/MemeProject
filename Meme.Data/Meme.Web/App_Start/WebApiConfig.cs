using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Meme.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Meme",
                routeTemplate: "api/{Meme}/{id}",
                defaults: new { controller = "Meme", id = RouteParameter.Optional }
            );
        }
    }
}
