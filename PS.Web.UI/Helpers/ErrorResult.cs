using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using PS.Infrastructure;

namespace PS.Web.UI.Helpers
{
    public class ErrorResult: IHttpActionResult
    {
        HttpResponseMessage response;
        HttpRequestMessage request;

        public ErrorResult(ValidationResult error, HttpRequestMessage request)
        {
            if (error != null)
            {
                this.request = request;

                var errorMessage = new System.Web.Http.HttpError(error.Message ?? "") { { "ErrorCode", error.ErrorCode } };
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            } 
            else
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Empty);
            }
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }
    }
}