using System;
using System.Collections;
using System.Collections.Generic;
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
        public IHttpActionResult Get(HREmployee searchObj, int pageSize, int currentPage)
        {
            var serviceList = GetAllList(searchObj, pageSize, currentPage);
            return GetOkResult(serviceList);

        }

        [System.Web.Http.Route("HasHREmployee")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult HasHREmployee(HREmployee searchObj)
        {
            var serviceList = GetAllList(searchObj, 2, 1).Count() > 0 ? true : false;
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
            obj.CityID = String.IsNullOrEmpty(obj.CityID) ? null : obj.CityID;
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
            obj.HREmployeeType =null;
            obj.CityID = String.IsNullOrEmpty(obj.CityID) ? null : obj.CityID; 
            var serviceObj = this.hREmployeeService.Update(obj);
            return GetOkResult(serviceObj);
        }

        #endregion API

        #region Others Method

        public IEnumerable<HREmployee> GetAllList(HREmployee searchObject, int pageSize, int currentPage)
        {

            string searchQuery = string.Empty;
            string concat = string.Empty;
            string hasSearchString = String.Empty;

            if (!string.IsNullOrEmpty(searchObject.Code))
            {
                searchQuery += concat + " HREmployee.Code LIKE '%" + searchObject.Code + "%'";
                concat = " OR ";
                hasSearchString = " AND ";
            }
            if (!string.IsNullOrEmpty(searchObject.Name))
            {
                searchQuery += concat + "HREmployee.Name LIKE '%" + searchObject.Name + "%'";
                concat = " OR ";
                hasSearchString = " AND ";
            }
            if (!string.IsNullOrEmpty(searchObject.ID))
            {
                searchQuery += concat + "HREmployee.ID LIKE '%" + searchObject.ID + "%'";
                concat = " OR ";
                hasSearchString = " AND ";
            }
            if (!string.IsNullOrEmpty(searchObject.EmployeeTypeID))
            {
                searchQuery += concat + "HREmployee.EmployeeTypeID LIKE '%" + searchObject.EmployeeTypeID + "%'";
                concat = " OR ";
                hasSearchString = " AND ";
            }


            searchQuery = !string.IsNullOrEmpty(hasSearchString)
                ? "(HREmployee.ActionType != 'DELETE') " + hasSearchString + searchQuery
                : "(HREmployee.ActionType != 'DELETE') ";
            var data = hREmployeeService.Get(pageSize, currentPage, "HREmployee.ActionDate DESC", searchQuery).ToList();

            return data;
        }

        #endregion
    }
}


