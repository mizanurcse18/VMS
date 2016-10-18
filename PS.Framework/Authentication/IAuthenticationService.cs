using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PS.Model.Models;


namespace PS.Framework.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public partial interface IAuthenticationService
    {
        string SignIn(HREmployee user, OAuthAuthorizationServerOptions options, IAuthenticationManager authManager);
        void SignOut(IAuthenticationManager authManager);
        string GetAuthenticatedUserIdentifier(HttpContextBase httpContext);
    }

}
