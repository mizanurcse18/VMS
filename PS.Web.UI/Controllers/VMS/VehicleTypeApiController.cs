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
    [System.Web.Http.RoutePrefix("api/VehicleType")]
    public class VehicleTypeApiController : BaseApiController
    {
        #region Properties

        public IVehicleTypeService vehicleTypeService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public VehicleTypeApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.vehicleTypeService = new VehicleTypeService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.vehicleTypeService.Get().Where(x => x.ActionType != "DELETE");
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchVehicleTypeByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.vehicleTypeService.Get();
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
            var listObj = this.vehicleTypeService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(VehicleType vehicleType)
        {
            vehicleType.ActionType = vehicleType.ID == null ? MasterDataConstants.ActionType.INSERT : vehicleType.ActionType = MasterDataConstants.ActionType.UPDATE;
            var isSuccess = vehicleType.ID == null ? this.vehicleTypeService.Save(vehicleType) : this.vehicleTypeService.Update(vehicleType);
            return GetOkResult(isSuccess);
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var vehicleTypeObj = vehicleTypeService.Get(id);
            vehicleTypeObj.ActionType = MasterDataConstants.ActionType.DELETE;
            var serviceObj = this.vehicleTypeService.Update(vehicleTypeObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


