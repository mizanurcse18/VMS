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
    [System.Web.Http.RoutePrefix("api/HREmployeeType")]
    public class HREmployeeTypeApiController : BaseApiController
    {
        #region Properties

        public IHREmployeeTypeService hREmployeeTypeService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public HREmployeeTypeApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.hREmployeeTypeService = new HREmployeeTypeService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.hREmployeeTypeService.Get().ToList();
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchHREmployeeTypeByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.hREmployeeTypeService.Get();
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
            var listObj = this.hREmployeeTypeService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(HREmployeeType hREmployeeType)
        {
            var isSuccess = hREmployeeType.ID == null ? this.hREmployeeTypeService.Save(hREmployeeType) : this.hREmployeeTypeService.Update(hREmployeeType);
            return GetOkResult(isSuccess);
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var hREmployeeTypeObj = hREmployeeTypeService.Get(id);
            
            var serviceObj = this.hREmployeeTypeService.Update(hREmployeeTypeObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


