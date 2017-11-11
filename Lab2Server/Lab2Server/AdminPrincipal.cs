using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Lab2Server
{
    public class AdminPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public AdminPrincipal ( string email )
        {
            Identity = new GenericIdentity(email);
        }

        public bool IsInRole(string role)
        {
            return true;
        }


    }
}