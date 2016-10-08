using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PS.Framework.Fakes;
//using PS.Model.Models;

namespace PS.Framework.Authentication
{
    public class AuthenticationService //: IAuthenticationService
    {

        /// <summary>
        /// Signin
        /// </summary>
        /// <param name="user"></param>
        /// <param name="options"></param>
        /// <param name="authManager"></param>
        /// <returns></returns>
        //public string SignIn(User user, OAuthAuthorizationServerOptions options, IAuthenticationManager authManager)
        //{

        //    ClaimsIdentity identity = new ClaimsIdentity(options.AuthenticationType);

        //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        //    //identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
        //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));


        //    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());

        //    var currentUtc = new SystemClock().UtcNow;
        //    ticket.Properties.IssuedUtc = currentUtc;

        //    // TODO:
        //    // Commented inorder to avoid authorization timeout after 1 hour. 
        //    //ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(60));      


        //    authManager.SignIn(identity);

        //    return options.AccessTokenFormat.Protect(ticket);
        //}

        /// <summary>
        /// Signout
        /// </summary>
        /// <param name="authManager"></param>
        public void SignOut(IAuthenticationManager authManager)
        {
            authManager.SignOut();
        }

        /// <summary>
        /// Return unique Id
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public string GetAuthenticatedUserIdentifier(HttpContextBase httpContext)
        {
            IOwinContext ctx = httpContext.IsFakeContext() ? httpContext.GetFakeOwinContext() : httpContext.Request.GetOwinContext();
            ClaimsPrincipal userPrincipal = ctx.Authentication.User;
            IEnumerable<Claim> claims = userPrincipal.Claims;
            var claim = claims.FirstOrDefault(item => item.Type == ClaimTypes.NameIdentifier);
            return claim.Value ?? "";
        }
    }
}
