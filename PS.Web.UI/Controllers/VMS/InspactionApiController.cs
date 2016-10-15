using System;
using System.Linq;
using System.Web.Http;
using PS.Framework;
using PS.Framework.Authentication;
using PS.Model.Models;
using PS.Service;
using PS.Web.UI.Models;

namespace PS.Web.UI.Controllers.Vehicle
{
    //[Authorize]
    //[Validation]
    //[ValidationAttribute]
    //[HostAuthentication(DefaultAuthenticationTypes.ApplicationCookie)]
    [System.Web.Http.RoutePrefix("api/Inspaction")]
    public class InspactionApiController : BaseApiController
    {
        #region Properties

        public IInspactionService inspactionService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public InspactionApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.inspactionService = new InspactionService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.inspactionService.Get().Where(x => x.ActionType != "DELETE");
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchInspactionByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.inspactionService.Get();
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("GetAllByPage")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int page)
        {
            int totalPage = 0;
            int totalRecord = 0;
            int pageSize = 10;
            var listObj = this.inspactionService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(Inspaction inspaction)
        {
            inspaction.ActionType = inspaction.ID == null ? MasterDataConstants.ActionType.INSERT : inspaction.ActionType = MasterDataConstants.ActionType.UPDATE;
            var isSuccess = inspaction.ID == null ? this.inspactionService.Save(inspaction) : this.inspactionService.Update(inspaction);
            return GetOkResult(isSuccess);
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var inspactionObj = inspactionService.Get(id);
            inspactionObj.ActionType = MasterDataConstants.ActionType.DELETE;
            var serviceObj = this.inspactionService.Update(inspactionObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


