using PS.Infrastructure;
using PS.Model;
using PS.Model.Enums;


namespace PS.Service.Interface
{

    /// <summary>
    /// Customer registration interface
    /// </summary>
    public partial interface IUserRegistrationService
    {
       

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <param name="adminID">Administrator ID</param>
        /// <param name="roleId">User Role</param>
        /// <returns>Result</returns>
        ValidationResult ValidateUser(string usernameOrEmail, string password, string adminId, Role role);

        /// <summary>
        /// To Register User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //ValidationResult RegisterUser(User user);

        /// <summary>
        /// Validate's a user's username/password credentials.
        /// Returns a LoginValidationResult with fields for:
        /// 1) If the user's parameter username/password combination were correct.
        /// 2) The user's id, if their username/password was correct.
        /// 3) The user's name if their username/password was correct.
        /// See ExternalLogin for to login with facebook or twitter.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //LoginValidationResult Login(string username, string password);


        /// <summary>
        /// Validate's a user's exeternal authentication credentils.
        /// Returns a LoginValidationResult with fields for:
        /// 1) If the user's parameter authentication type/id combination were correct.
        /// 2) The user's id, if their authentication type/id was correct.
        /// 3) The user's name if their authentication type/id was correct.
        /// </summary>
        //LoginValidationResult ExternalLogin(UserAuthenticationType authenticationType, string externalAuthenticationId);

        /// <summary>
        /// Validates that the parameters are valid to create an account, and creates an account if so.
        /// Creates a new account with the parameter username, email and password.
        /// See the other overload for the create account with facebook or twitter.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //CreateAccountValidationResult CreateAccount(string username, string email, string password);

        /// <summary>
        /// Validates that the parameters are valid to create an account, and creates an account if so.
        /// Creates a new account with the parameter username, email, external authentication type, and external authentication id.
        /// Used for external authentication scenarios.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="authenticationType"></param>
        /// <param name="externalAuthenticationId"></param>
        /// <param name="hasCompletedCelebrityTwitterAuth"></param>
        /// <returns></returns>
        //CreateAccountValidationResult CreateAccount(string username, string email, UserAuthenticationType authenticationType, string externalAuthenticationId, bool hasCompletedCelebrityTwitterAuth);

      
        /// <summary>
        /// Returns true if the email/username was found and the email was sent; false if not.
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <returns></returns>
        //bool SendForgottenPassword(string usernameOrEmail);

        //bool SendContactUs(string name, string email, string telephone, string message);

        /// <summary>
        /// To send User registration email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       // ValidationResult SendUserRegistrationEmail(User user);

        /// <summary>
        /// To Edit User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Validation Result</returns>
        //ValidationResult UpdateUserProfile(User user, string newPassword);

        /// <summary>
        /// To Validate given Device details.
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceRegisterID"></param>
        /// <returns></returns>
        ValidationResult ValidateUserDevice(DeviceType deviceType, string deviceToken, string deviceRegisterID);

        ///// <summary>
        ///// To Validate User Login in Social Network Site.
        ///// </summary>
        ///// <param name="userType"></param>
        ///// <param name="externalAuthenticationID"></param>
        ///// <param name="socialSiteToken"></param>
        ///// <param name="socialSiteTokenSecret"></param>
        ///// <returns></returns>
        //ValidationResult ValidateSocialNetworkLogin(Zing.Api.Contracts.Enums.AuthenticationType userType, string externalAuthenticationID, string socialSiteToken, string socialSiteTokenSecret);

        ///// <summary>
        ///// To Update Login User Device Details.
        ///// </summary>
        ///// <param name="userID"></param>
        ///// <param name="deviceType"></param>
        ///// <param name="deviceToken"></param>
        ///// <param name="deviceSnsARN"></param>
        ///// <param name="deviceID"></param>
        ///// <returns></returns>
        //ValidationResult UpdateLoginDeviceDetails(long userID, DeviceType deviceType, string deviceToken, string deviceSnsARN, string deviceID);

        /// <summary>
        /// To Update User Last Login Details.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="authenticationType"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        ValidationResult UpdateLoginUserDetails(string userID, UserAuthenticationType authenticationType, string deviceToken, DeviceType deviceType);

        /// <summary>
        /// To Logout a user from a Device.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        ValidationResult LogoutDeviceUser(string userID);
    }

}
