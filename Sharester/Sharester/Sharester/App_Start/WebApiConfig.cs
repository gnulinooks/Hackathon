using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Sharester
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi1",
                routeTemplate: "api/{controller}/GetSearch/{query}/{category}",
                defaults: new {  },
                constraints: new { controller = "SearchItem", HttpMethod = new HttpMethodConstraint(HttpMethod.Get)}
            );


            #region Posts API
            config.Routes.MapHttpRoute(
                name: "PostGetAPI",
                routeTemplate: "api/{controller}/posts/{postid}",
                defaults: new { },
                constraints: new { controller = "post", HttpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "PostPostAPI",
                routeTemplate: "api/{controller}/post/{postid}",
                defaults: new { },
                constraints: new { controller = "post", HttpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "PostPutAPI",
                routeTemplate: "api/{controller}/create/{userId}",
                defaults: new { },
                constraints: new { controller = "post", HttpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            #endregion
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}