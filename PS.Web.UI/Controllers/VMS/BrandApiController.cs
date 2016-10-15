using System;
using System.Linq;
using System.Web.Http;
using PS.Framework;
using PS.Framework.Authentication;
using PS.Model.Models;
using PS.Service;

namespace PS.Web.UI.Controllers.Vehicle
{
    //[Authorize]
    //[Validation]
    //[ValidationAttribute]
    //[HostAuthentication(DefaultAuthenticationTypes.ApplicationCookie)]
    [System.Web.Http.RoutePrefix("api/Brand")]
    public class BrandApiController : BaseApiController
    {
        #region Properties

        public IBrandService brandService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public BrandApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.brandService = new BrandService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.brandService.Get().ToList();
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchBrandByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.brandService.Get();
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
            var listObj = this.brandService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(Brand brand)
        {
            var isSuccess = brand.ID == null ? this.brandService.Save(brand) : this.brandService.Update(brand);
            return GetOkResult(isSuccess);
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var brandObj = brandService.Get(id);
            
            var serviceObj = this.brandService.Update(brandObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


