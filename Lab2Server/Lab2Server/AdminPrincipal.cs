using System.Security.Principal;

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