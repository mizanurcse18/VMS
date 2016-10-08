
namespace PS.Services.Cache
{
    public static class CacheKeys
    {
        public const string USERSESSION_KEY = "Zing.User.{0}";
        public const string USERSESSION_ROLE_KEY = "Zing.UserRole.{0}";
        public const string USERSESSION_BROADCASTER_KEY = "Zing.UserBr.{0}";
        public const string USERSESSION_SHOW_KEY = "Zing.UserShow.{0}";

        public const int DEFAULT_CACHE_DURATION_SECS = 10;

        #region UserService keys
        public const string USERSERVICE_GETUSERBYUSERNAME_KEY = "Zing.UserService.{0}";
        #endregion

    }
}
