using Microsoft.AspNetCore.Routing;
using NWebsec.AspNetCore.Core.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using u
namespace RepoUnitTest.Utilities
{
    public static class CreateController
    {
        public static T Create<T>(RouteData routeData = null)
            where T : Controller, new()
        {
            T controller = new T();

            // Create an MVC Controller Context
            var wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);

            if (routeData == null)
                routeData = new RouteData();

            if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
                routeData.Values.Add("controller", controller.GetType().Name
                                                            .ToLower()
                                                            .Replace("controller", ""));

            controller.ControllerContext = new System.Web.ControllerContext(wrapper, routeData, controller);
            return controller;
        }
    }
}
