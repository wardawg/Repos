using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace RepoUnitTest.Utilities
{
   public class SetWebControllerInstance
    {

        public static void Initialize(Controller controller)
        {

            controller.ControllerContext = new ControllerContext();
        }


        public static void Initialize(ApiController controller)
        {

            var config = new HttpConfiguration();
       // var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/products");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "products" } });
            var prequest = new HttpRequestMessage();


            controller.ControllerContext = new HttpControllerContext(config, routeData, prequest);
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }
    }
}
