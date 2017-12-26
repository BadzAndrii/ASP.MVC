using Lab2Server.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Lab2Server.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid) {

                var aLogin = ConfigurationManager.AppSettings["adminlogin"];
                var aPassword = ConfigurationManager.AppSettings["adminpassword"];

                if (string.Equals(aLogin,model.Email,StringComparison.InvariantCultureIgnoreCase) && aPassword == model.Password)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string userData = serializer.Serialize(model);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             model.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    Response.Cookies.Add(faCookie);

                    return Redirect("/Books/Index");
                }
                else
                {
                    ModelState.AddModelError("Login", "Incorrect username or password.");
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            //Clear User Auth tiket cookie
            Request.Cookies.Remove(FormsAuthentication.FormsCookieName);

            // it will clear the session at the end of request
            Session.Abandon();
            
            return RedirectToAction("Login");
        }
    }
}