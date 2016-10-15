using System;
using System.Linq;
using System.Web.Http;
using PS.Framework;
using PS.Framework.Authentication;
using PS.Model.Models;
using PS.Service;
using PS.Web.UI.Models;

namespace PS.Web.UI.Controllers.VMS
{
    //[Authorize]
    //[Validation]
    //[ValidationAttribute]
    //[HostAuthentication(DefaultAuthenticationTypes.ApplicationCookie)]
    [System.Web.Http.RoutePrefix("api/VMS/HREmployee")]
    public class HREmployeeApiController : BaseApiController
    {
        #region Properties

        public IHREmployeeService hREmployeeService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public HREmployeeApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.hREmployeeService = new HREmployeeService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Get(HREmployee obj, int pageSize)
        {
            var serviceList = this.hREmployeeService.Get().Where(x => x.ActionType != "DELETE");
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(HREmployee obj)
        {
            var isSuccess = false;
            try
            {
                isSuccess = SaveOrUpdate(obj);
            }
            catch
            {

            }
            return GetOkResult(isSuccess);
        }

        private bool SaveOrUpdate(HREmployee obj)
        {
            var isSuccess = false;
            obj.ActionDate = DateTime.Now;
            obj.UpdatedBy = CurrentUserID;
            if (IsNew(obj.ID))
            {
                obj.CreateDate = DateTime.Now;
                obj.CreatedBy = CurrentUserID;
                obj.ActionType = MasterDataConstants.ActionType.INSERT;
                isSuccess = hREmployeeService.Save(obj);
            }
            else
            {
                obj.ActionType = MasterDataConstants.ActionType.UPDATE;
                isSuccess = hREmployeeService.Update(obj);
            }
            return isSuccess;
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Delete(HREmployee obj)
        {
            obj.ActionDate = DateTime.Now;
            obj.UpdatedBy = CurrentUserID;
            obj.ActionType = MasterDataConstants.ActionType.DELETE;
            var serviceObj = this.hREmployeeService.Update(obj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


