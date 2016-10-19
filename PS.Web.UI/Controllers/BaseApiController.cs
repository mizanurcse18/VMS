//Created by Mizan 
//Undefined-Jun-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PS.Framework;
using PS.Infrastructure;
using PS.Model.Models;
using PS.Service;
using PS.Web.UI.Helpers;
using PS.Web.UI.Models;
using PS.Web.UI.Utility;

namespace PS.Web.UI.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IWorkContext workContext;

        public BaseApiController(IWorkContext workContext)
        {
            if (workContext == null) throw new ArgumentNullException("workContext");

            this.workContext = workContext;
        }

        protected IHttpActionResult GetErrorResult(ValidationResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            return new ErrorResult(result, Request);
        }

        protected IHttpActionResult GetOkResult<T>(T result)
        {
            if (result == null)
            {
                return Ok();
            }

            return Ok(result);
        }

        /// <summary>
        /// Returns the current work context
        /// </summary>
        /// <remarks>
        /// Using this method requires the user to be authorized.
        /// </remarks>
        public IWorkContext SessionContext
        {
            get
            {
                return workContext;
            }
        }

        protected HREmployee CurrentUser
        {
            get
            {
                return workContext.CurrentUser;
            }
        }
        protected bool IsNew(string id)
        {
            return MisUtil.IsNew(id);
        }

        protected string CurrentWorkingUnitID
        {
            get { return "737266bf-3c17-46eb-91e7-a4a5e8fff008"; }
        }

        protected string CurrentUserID
        {
            get { return "1"; }
        }
        protected int CurrentReceiveType
        {
            get { return MasterDataConstants.INVReceiveType.GODWON; }
        }


    }
}