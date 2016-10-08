using Microsoft.AspNet.SignalR;
using PS.Model;

namespace PS.Framework.Filters
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeRoleAttribute(params Role[] roles)
            : base()
        {
            Roles = string.Join(",", roles);
        }

    }
}