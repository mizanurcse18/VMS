using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;
using Microsoft.Owin;

namespace PS.Framework.Fakes
{
    public class FakeHttpContext : HttpContextBase
    {
        private readonly HttpCookieCollection cookies;
        private readonly NameValueCollection formParams;
        private IPrincipal principal;
        private readonly NameValueCollection queryStringParams;
        private readonly string relativeUrl;
        private readonly string method;
        private readonly SessionStateItemCollection sessionItems;
        private readonly NameValueCollection serverVariables;
        private HttpResponseBase response;
        private HttpRequestBase request;
        private readonly Dictionary<object, object> items;
        private IOwinContext owinContext;

        public FakeHttpContext(IOwinContext owinContext)
            : this(null, null, null, null, null, null, null, null, owinContext, null)
        {
        }

        public FakeHttpContext(IOwinContext owinContext, HttpRequestBase request)
            : this(null, null, null, null, null, null, null, null, owinContext, request)
        {
        }

        public FakeHttpContext(string relativeUrl, string method)
            : this(relativeUrl, method, null, null, null, null, null, null, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl)
            : this(relativeUrl, null, null, null, null, null, null, null, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl,
            IPrincipal principal, NameValueCollection formParams,
            NameValueCollection queryStringParams, HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems, NameValueCollection serverVariables)
            : this(relativeUrl, null, principal, formParams, queryStringParams, cookies, sessionItems, serverVariables, null, null)
        {
        }

        public FakeHttpContext(string relativeUrl, string method,
            IPrincipal principal, NameValueCollection formParams,
            NameValueCollection queryStringParams, HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems, NameValueCollection serverVariables, IOwinContext owinContext, HttpRequestBase request)
        {
            this.relativeUrl = relativeUrl;
            this.method = method;
            this.principal = principal;
            this.formParams = formParams;
            this.queryStringParams = queryStringParams;
            this.cookies = cookies;
            this.sessionItems = sessionItems;
            this.serverVariables = serverVariables;

            items = new Dictionary<object, object>();
            this.owinContext = owinContext;
            this.request = request;
        }

        public override HttpRequestBase Request
        {
            get
            {
                return request;
            }
        }

        public void SetRequest(HttpRequestBase request)
        {
            this.request = request;
        }

        public IOwinContext GetOwinContext()
        {
            return owinContext;
        }
    }
}
