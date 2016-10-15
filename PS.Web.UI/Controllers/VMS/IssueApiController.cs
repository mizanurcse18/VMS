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
    [System.Web.Http.RoutePrefix("api/Issue")]
    public class IssueApiController : BaseApiController
    {
        #region Properties

        public IIssueService issueService;
        private readonly IAuthenticationService authService;
        private readonly IWorkContext workContext;

        #endregion Properties

        #region Ctr

        public IssueApiController(IAuthenticationService authService, IWorkContext workContext)
            : base(workContext)
        {
            this.authService = authService;
            this.workContext = workContext;
            this.issueService = new IssueService();
        }

        #endregion Ctr

        #region API

        [System.Web.Http.Route("GetAll")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var serviceList = this.issueService.Get().Where(x => x.ActionType != "DELETE");
            return GetOkResult(serviceList);
        }

        [System.Web.Http.Route("SearchIssueByUserInput")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string searchText)
        {
            var serviceList = this.issueService.Get();
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
            var listObj = this.issueService.Get();

            totalRecord = listObj.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            listObj = listObj.Skip((Convert.ToInt16(page) - 1) * pageSize).Take(pageSize).ToList();

            return GetOkResult(listObj);
        }

        [System.Web.Http.Route("Save")]
        //[AllowAnonymous]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Save(Issue issue)
        {
            issue.ActionType = issue.ID == null ? MasterDataConstants.ActionType.INSERT : issue.ActionType = MasterDataConstants.ActionType.UPDATE;
            var isSuccess = issue.ID == null ? this.issueService.Save(issue) : this.issueService.Update(issue);
            return GetOkResult(isSuccess);
        }

        [System.Web.Http.Route("Delete")]
        //[AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var issueObj = issueService.Get(id);
            issueObj.ActionType = MasterDataConstants.ActionType.DELETE;
            var serviceObj = this.issueService.Update(issueObj);
            return GetOkResult(serviceObj);
        }

        #endregion API
    }
}


