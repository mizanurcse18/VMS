using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PS.Infrastructure.Logging;
using PS.Model.UtilityModels;


namespace PS.Framework.Filters
{
    public class ValidationAttribute : ActionFilterAttribute
    {

        private readonly Func<Dictionary<string, object>, bool> validate;

        private ILogger logger = LoggingFactory.GetLogger();

        public ValidationAttribute()
            : this(arguments => arguments.ContainsValue(null))
        { }

        public ValidationAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            validate = checkCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // To Trace Request for debug purpose in Log file INFO.
            try
            {
                if (actionContext.ActionArguments != null && actionContext.ActionArguments.Count > 0)
                {
                    var requestObject = actionContext.ActionArguments.Values;
                    string request = JsonConvert.SerializeObject(requestObject, new JsonSerializerSettings
                                                                  {
                                                                      ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                                  });

                    logger.Information(request);
                }
            }
            catch (Exception)
            {

            }

            if (validate(actionContext.ActionArguments))
            {
                actionContext.ModelState.AddModelError(ErrorCodes.ValidationError, "Invalid request format.");
            }

            if (actionContext.ModelState.IsValid == false)
            {
                var message = string.Join(" | ", actionContext.ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage));
                var errorMessagError = new System.Web.Http.HttpError(message) { { "ErrorCode", ErrorCodes.ValidationError } };
                actionContext.Response =
                    actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
            }
        }

    }
}
