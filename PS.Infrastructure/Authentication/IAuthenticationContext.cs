using Microsoft.Owin;

namespace PS.Infrastructure.Authentication
{
    public interface IAuthenticationContext
    {
        IOwinContext OwinContext { get; }
        string Username { get; }
        long UserId { get; }
    }
}
