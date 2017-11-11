using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Lab2Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var serializeModel = serializer.Deserialize<UserModel>(authTicket.UserData);

                var newUser = new AdminPrincipal(authTicket.Name);
                //newUser.Id = 100500;
                //newUser.FirstName = serializeModel.FirstName;
                //newUser.LastName = serializeModel.LastName;
                

                HttpContext.Current.User = newUser;
            }
        }
    }

}
