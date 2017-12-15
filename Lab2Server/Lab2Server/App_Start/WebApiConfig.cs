using System.Web.Http;

namespace Lab2Server.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            // Attribute routing.
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "apiDefault",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

    }
}