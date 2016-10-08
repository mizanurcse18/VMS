using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PS.Web.UI.Helpers
{
    public class OkResult<T> : OkNegotiatedContentResult<T>
    {
        HttpResponseMessage response;

        public OkResult(T content, ApiController controller)
            : base(content, controller)
        {
            if (content != null)
            {
                response = controller.Request.CreateResponse(HttpStatusCode.OK, content);
            }         
        }

        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }

    }
}