using System;
using System.Web;
using Microsoft.Owin;

namespace PS.Framework.Fakes
{
    public static class Extensions
    {
        public static IOwinContext GetFakeOwinContext(this HttpContextBase request)
        {
            return ((FakeHttpContext)request).GetOwinContext();
        }

        /// <summary>
        /// Indicates whether this context is fake
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <returns>Result</returns>
        public static bool IsFakeContext(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            return httpContext is FakeHttpContext;
        }

    }
}
