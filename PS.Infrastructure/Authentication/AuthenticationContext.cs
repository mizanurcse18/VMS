using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;

namespace PS.Infrastructure.Authentication
{
    public class AuthenticationContext : IAuthenticationContext
    {
        private HttpContextBase httpContext { get; set; }

        public AuthenticationContext(Func<HttpContextBase> httpContext)
        {
            this.httpContext = httpContext();
        }

        public IOwinContext OwinContext
        {
            get { return httpContext.Request.GetOwinContext(); }
        }

        public string Username
        {
            get
            {
                var usernameClaim =
                    OwinContext.Authentication.User.Claims.SingleOrDefault(a => a.Type == ClaimTypes.Name);
                if (usernameClaim == null)
                {
                    return null;
                }
                else
                {
                    return usernameClaim.Value;
                }
            }
        }

        public long UserId
        {
            get
            {
                var userIdClaim =
                 OwinContext.Authentication.User.Claims.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return default(int);
                }
                else
                {
                    return long.Parse(userIdClaim.Value);
                }
            }
        }
    }
}
