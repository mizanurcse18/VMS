using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PS.Framework.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext ctx = default(HttpContext);
            ctx = HttpContext.Current;

            base.OnActionExecuting(context);

            if (ctx.User.Identity.IsAuthenticated == false)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }
        }
    }
}