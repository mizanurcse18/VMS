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
    [System.Web.Http.RoutePrefix("api/VendorType")]
    public class VendorTypeApiController : BaseApiController
    {
        #region Properties

        public IVendorTypeService vendorTypeService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public VendorTypeApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.vendorTypeService = new VendorTypeService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.vendorTypeService.Get().Where(x => x.ActionType != "DELETE");
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchVendorTypeByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.vendorTypeService.Get();
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
            var listObj = this.vendorTypeService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(VendorType vendorType)
        {
            vendorType.ActionType = vendorType.ID == null ? MasterDataConstants.ActionType.INSERT : vendorType.ActionType = MasterDataConstants.ActionType.UPDATE;
            var isSuccess = vendorType.ID == null ? this.vendorTypeService.Save(vendorType) : this.vendorTypeService.Update(vendorType);
            return GetOkResult(isSuccess);
        }

        [Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var vendorTypeObj = vendorTypeService.Get(id);
            vendorTypeObj.ActionType = MasterDataConstants.ActionType.DELETE;
            var serviceObj = this.vendorTypeService.Update(vendorTypeObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


