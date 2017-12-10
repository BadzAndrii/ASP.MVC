using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using Lab2Server.Entities;
using Lab2Server.Repositories;

namespace Lab2Server
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Register your Context / webrequest
            container.Register<DataContext>(new WebRequestLifestyle());

            // Register your types, for instance:
            container.Register<ISageRepository, SagesRepository>();
            container.Register<IRepository<Book>, BooksRepository>();

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

#if DEBUG
            container.Verify();
#endif
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                HttpContext.Current.User = new AdminPrincipal(authTicket.Name);
            }
        }

        void Application_EndRequest(object sender, System.EventArgs e)
        {
            // If the user is not authorised to see this page or access this function, send them to the error page.
            if (Response.StatusCode == 401)
            {
                Response.ClearContent();
                Response.Redirect("/Error/Unauthorized");
            }
        }
    }

}
