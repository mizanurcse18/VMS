using System;
using PS.Infrastructure.Caching;


namespace PS.Services.Cache.Users
{
    /// <summary>
    /// Cached user service
    /// </summary>
    public class CachedUserService 
    {

        #region Fields

        private readonly ICacheManager cacheManager;
        
        private readonly Object getUserByUsernameLock = new Object();

        #endregion

        #region Ctor

        //public CachedUserService(ICacheManager cacheManager, IUserService realUserService)
        //{
        //    this.cacheManager = cacheManager;
        //    this.realUserService = realUserService;
        //}

        public CachedUserService(ICacheManager cacheManage)
        {
            this.cacheManager = cacheManager;
            //this.realUserService = realUserService;
        }

        #endregion

        public bool AssignShowToCommunityDirector(string programTitle, bool IsAssigned, int userId)
        {
            throw new System.NotImplementedException();
        }

        //public User GetUserByUsername(string username)
        //{
        //    lock (getUserByUsernameLock)
        //    {
        //        string key = string.Format(CacheKeys.USERSERVICE_GETUSERBYUSERNAME_KEY, username);
        //        User user = cacheManager.Get<User>(key);
        //        if (user == null)
        //        {
        //            //user = realUserService.GetUserByUsername(username);
        //            cacheManager.Set(key, user, TimeSpan.FromSeconds(CacheKeys.DEFAULT_CACHE_DURATION_SECS));
        //        }
        //        return user;
        //    }
        //}

        


        #region IUserService Members


       
        //ValidationResult IUserService.UpdateUserProfile(UpdateUserProfileRequest userProfile, long userId)
        //{
        //    throw new NotImplementedException();
        //}


        #endregion
    }
}
