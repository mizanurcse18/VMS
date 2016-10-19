using System;
using System.Web;
using PS.Framework.Authentication;
using PS.Framework.Filters;
using PS.Infrastructure.Caching;
using PS.Model;
using PS.Model.Models;
using PS.Services.Cache;

namespace PS.Framework
{
    public class WebWorkContext : IWorkContext
    {

        #region Fields

        private readonly HttpContextBase httpContext;
        private readonly IAuthenticationService authenticationService;
        private readonly ICacheManager cacheManager;
        private string userGuid = "";

        #endregion

        #region Ctor

        public WebWorkContext(HttpContextBase httpContext, IAuthenticationService authenticationService,
            ICacheManager cacheManager)
        {
            this.httpContext = httpContext;
            this.authenticationService = authenticationService;
            this.cacheManager = cacheManager;
        }

        #endregion

        #region Utilities

        private string GetUserGuid()
        {
            userGuid = string.IsNullOrEmpty(userGuid) ? authenticationService.GetAuthenticatedUserIdentifier(httpContext) : userGuid;
            return userGuid;
        }

        private string GetUserEntityKey()
        {
            return string.Format(CacheKeys.USERSESSION_KEY, GetUserGuid());
        }

        private string GetUserEntityKey(string userGuid)
        {
            return string.Format(CacheKeys.USERSESSION_KEY, userGuid);
        }

        private string GetRoleEntityKey()
        {
            return string.Format(CacheKeys.USERSESSION_ROLE_KEY, GetUserGuid());
        }

        private string GetRoleEntityKey(string userGuid)
        {
            return string.Format(CacheKeys.USERSESSION_ROLE_KEY, userGuid);
        }

        #endregion

        public void SetUser(string userGuid, HREmployee user, Role impersonatedRole)
        {
            cacheManager.Set(GetUserEntityKey(userGuid), user, TimeSpan.FromDays(1));
            cacheManager.Set(GetRoleEntityKey(userGuid), impersonatedRole);


            //cacheManager.Set(GetBroadcasterEntityKey(userGuid), broadcaster);
            //cacheManager.Set(GetShowEntityKey(userGuid), new Show());
        }

        public HREmployee CurrentUser
        {
            get
            {
                return cacheManager.Get<HREmployee>(GetUserEntityKey());
            }
        }

        public Role CurrentRole
        {
            get
            {
                return cacheManager.Get<Role>(GetRoleEntityKey());
            }
            set
            {
                cacheManager.Set(GetRoleEntityKey(), value);
            }
        }
    }
}
