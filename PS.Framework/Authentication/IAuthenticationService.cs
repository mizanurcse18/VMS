using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;


namespace PS.Framework.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public partial interface IAuthenticationService
    {
        //string SignIn(User user, OAuthAuthorizationServerOptions options, IAuthenticationManager authManager);
        void SignOut(IAuthenticationManager authManager);
        string GetAuthenticatedUserIdentifier(HttpContextBase httpContext);
    }

}
