using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using PS.Model.UtilityModels;

namespace PS.Framework.Filters
{
    public class WebApiAuthenicationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var headers = request.Headers;
            HttpContext ctx = default(HttpContext);
            ctx = HttpContext.Current;
            if (ctx.User.Identity.IsAuthenticated == false)
            {
                var errorMessagError = new System.Web.Http.HttpError("Invalid Session") { { "ErrorCode", ErrorCodes.ValidationError } };
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
            }
        }
    }

}