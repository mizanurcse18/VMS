using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using PS.Data.Infrastructure;
using PS.Infrastructure;
using PS.Infrastructure.Configuration;
using PS.Infrastructure.Localization;
using PS.Infrastructure.Logging;
using PS.Model;
using PS.Model.Enums;

using PS.Model.UtilityModels;
using PS.Service.Interface;


namespace PS.Service
{

    /// <summary>
    /// User registration service
    /// </summary>
    public partial class UserRegistrationService //: IUserRegistrationService
    {

        #region Fields

        //private readonly ISEUserService userService;
        private readonly ILocalizationService localizationService;
        private readonly ILogger logger;
        private readonly IApplicationSettings applicationSettings;

        // This key should never change, because if it does, all of the current user passwords in the db will no longer work.
        //  Storing passwords in a retrievable format isn't a best practice, 
        //  but the current requirements around forgotton password necessitate it.
        private const string SecretEncryptionKey = "@0sLaoWkcm.,)X=b";

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="customerService">User service</param>
        //public UserRegistrationService(ISEUserService userService, ILocalizationService localizationService
        //     )
        //{
        //    this.userService = userService;
        //    this.localizationService = localizationService;
        //    //this.repository = repository;
        //    //this.logger = logger;
        //    //this.applicationSettings = applicationSettings;
        //}

        #endregion

        #region Methods


        /// <summary>
        /// To validate a login email user.
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <param name="password"></param>
        /// <param name="adminID"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public ValidationResult ValidateUser(string usernameOrEmail, string password, string adminID, Role role)
        {
            // Getting the User details.
            //SEUser user = userService.GetUserByUsername(usernameOrEmail);

            bool isValid = false;
            //Only broadcaster admin can impersonate as broadcaster user



            // Encrypting the password. 
            //string pwd = encrService.EncryptText(password, SecretEncryptionKey);
            //string pwd = encrService.CreatePasswordHash(password, user.UserPwdSalt);

            // Validating the password.
            //isValid = password == user.Password.ToString();

            if (!isValid)
                return new ValidationResult(ErrorCodes.UserValidationError, localizationService.GetResource("InvalidUsernamePassword"));

            return ValidationResult.Success;
        }

        /// <summary>
        /// To Register User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Validation Result</returns>
        //public ValidationResult RegisterUser(User user)
        //{
        //    string errorNumber = string.Empty;
        //    string password = user.UserPwd;
        //    List<OutofShowQuestion> pendingQuestion = null;

        //    User existingUser = userService.GetUserByUsername(user.Username);
        //    if (existingUser != null && existingUser.Username == user.Username && existingUser.AuthenticationType == user.AuthenticationType)
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("UserAlreadyExists"));
        //    }

        //    // Password Validation.
        //    if (user.AuthenticationType == (short)UserAuthenticationType.UsernamePassword && string.IsNullOrEmpty(user.UserPwd))
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    }
        //    if (user.AuthenticationType == (short)UserAuthenticationType.UsernamePassword && user.UserPwd.Length < 7)
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    }

        //    // Email Validation.
        //    if (user.AuthenticationType == (short)UserAuthenticationType.UsernamePassword && string.IsNullOrEmpty(user.EmailID))
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    }

        //    // SocialSite UserID Validation.
        //    //if (((user.AuthenticationType == (short)UserAuthenticationType.ExternalFacebook) || (user.AuthenticationType == (short)UserAuthenticationType.ExternalTwitter))
        //    //      && string.IsNullOrEmpty(user.ExternalAuthenticationID))
        //    //{
        //    //    return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    //}

        //    // SocialSite Facebook Validation.
        //    if ((user.AuthenticationType == (short)UserAuthenticationType.ExternalFacebook) && (string.IsNullOrEmpty(user.ExternalAuthenticationID)
        //        || string.IsNullOrEmpty(user.SocialSiteToken)))
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    }
        //    // SocialSite Twitter Validation.
        //    if ((user.AuthenticationType == (short)UserAuthenticationType.ExternalTwitter) && (string.IsNullOrEmpty(user.ExternalAuthenticationID)
        //        || string.IsNullOrEmpty(user.SocialSiteToken) || string.IsNullOrEmpty(user.SocialSiteTokenSecret)))
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidData"));
        //    }
        //    // SocialSite Login Credential Validation.
        //    if ((user.AuthenticationType == (short)UserAuthenticationType.ExternalFacebook) || (user.AuthenticationType == (short)UserAuthenticationType.ExternalTwitter))
        //    {
        //        var result = ValidateSocialNetworkLogin((Zing.Api.Contracts.Enums.AuthenticationType)user.AuthenticationType, user.ExternalAuthenticationID, user.SocialSiteToken, user.SocialSiteTokenSecret);
        //        if (result != ValidationResult.Success)
        //        {
        //            return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidSocialSiteLogin"));
        //        }
        //    }

        //    // Validation of Device Register ID for Android devices.
        //    if (!string.IsNullOrEmpty(user.DeviceToken) && user.DeviceTypeID == (short)DeviceType.Android && string.IsNullOrEmpty(user.SnsARN))
        //    {
        //        return new ValidationResult(ErrorCodes.RegisterError, localizationService.GetResource("InvalidDeviceRegisterID"));
        //    }

        //    // Password encryption.
        //    if (!string.IsNullOrEmpty(user.UserPwd))
        //    {
        //        //Changed pwd to use encryption instead of hashing as per Zing team's requirement
        //        //string saltKey = encrService.CreateSaltKey(5);
        //        //string pwdHash = encrService.CreatePasswordHash(user.UserPwd, saltKey);
        //        //user.UserPwd = pwdHash;
        //        //user.UserPwdSalt = saltKey;

        //        user.UserPwd = encrService.EncryptText(user.UserPwd, SecretEncryptionKey); //TODO: change to use machine encryption key
        //        user.UserPwdSalt = "";
        //    }

        //    if (user.Role != Zing.Model.Role.BroadcasterAdmin)
        //    {
        //        user.GenerateChatCredentials();

        //        // Creating User in XMPP server.
        //        IQResponse chatResponse = xmppService.CreateUser(user.ChatUsername, user.ChatUserPwd);
        //        if (chatResponse.Type == IQType.error)
        //        {
        //            logger.Error(string.Format("Chat register error: {0}", chatResponse.Error));
        //            return new ValidationResult(ErrorCodes.RegisterError, string.Format("Unable to connect to server. Please try again later. {0}", chatResponse.Error));
        //        }
        //    }

        //    // SNS-ARN creation for iOS/Android Devices.
        //    if (!string.IsNullOrEmpty(user.DeviceToken))
        //    {
        //        // Checking for DeviceToken existence.
        //        //var userDevice = repository.FindOne<EfDeviceUser>(
        //        //                 u => u.DeviceToken == user.DeviceToken && u.DeviceType == (DeviceType)user.DeviceTypeID);
        //        var userDevice = repository.FindOne<EfDeviceSnsARN>(
        //                         u => u.DeviceToken == user.DeviceToken && u.DeviceTypeID == (DeviceType)user.DeviceTypeID);

        //        if (userDevice != null && userDevice.SnsARN != null)
        //        {
        //            user.SnsARN = userDevice.SnsARN.Trim();
        //        }
        //        else
        //        {
        //            //Create ARN for iOS/Android Devices.
        //            SNSPushService pushService = (SNSPushService)pushBroker.GetRegistrations<SNSNotification>().FirstOrDefault();
        //            if (pushService != null)
        //            {
        //                string snsARN = pushService.RegisterDevice(user.DeviceToken, user.DeviceTypeID);
        //                user.SnsARN = snsARN;
        //            }
        //        }
        //    }

        //    if (user.AuthenticationType == (short)UserAuthenticationType.ExternalTwitter)
        //    {
        //        bool isCeleb = IsCelebrityTwitterHandleAuthorized(user.Username);
        //        user.IsCelebrity = isCeleb;
        //        if (isCeleb)
        //        {
        //            IQResponse response = xmppService.CreateNode(user.ChatUsername);
        //            if (response.Type == IQType.error)
        //            {
        //                logger.Error(string.Format("Celeb pubsub error: {0}", response.Error));
        //                return new ValidationResult(ErrorCodes.RegisterError, string.Format("Celeb pubsub error. {0}", response.Error));
        //            }
        //            user.CelebrityPubSubNodeName = user.ChatUsername;
        //        }
        //    }

        //    // Creating the User.
        //    userDataService.AddUser(user, out errorNumber, out pendingQuestion);
        //    if (user.Role == Role.BroadcasterAdmin)
        //    {
        //        user.UserPwd = password;
        //    }
        //    if (errorNumber.Length > 0)
        //    {
        //        return new ValidationResult(errorNumber, localizationService.GetResource(errorNumber));
        //    }

        //    // Sending  notification email to the user.
        //    if (user.Role == Role.AppUser && user.AuthenticationType == (short)UserAuthenticationType.UsernamePassword && user.EmailID.Length > 0)
        //    {
        //        UserRegisterNotificationMail(user.EmailID, user.EmailID, password);
        //    }

        //    // Sending Push Notification against OutofShow Questions.
        //    if (pendingQuestion != null)
        //    {
        //        SendOutofShowQuestionPushNotification(user.UserId, user.SnsARN, (DeviceType)user.DeviceTypeID, pendingQuestion);
        //    }

        //    return ValidationResult.Success;
        //}

        /// <summary>
        /// To Edit User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Validation Result</returns>
        //public ValidationResult UpdateUserProfile(User user, string newPassword)
        //{
        //    string errorNumber = string.Empty;
        //    string password = user.UserPwd;

        //    if (!string.IsNullOrEmpty(newPassword))
        //    {
        //        user.UserPwd = encrService.EncryptText(newPassword, SecretEncryptionKey);
        //    }
        //    if (user.Role == Role.BroadcasterAdmin)
        //    {
        //        userDataService.AddEditCallLetter(user.CallLetterCode, user.SecurityCode, user.AdministratorId, out errorNumber);
        //        if (errorNumber.Length > 0)
        //            return new ValidationResult(errorNumber, localizationService.GetResource(errorNumber));
        //    }
        //    // Creating the User.
        //    userDataService.SetUser(user, out errorNumber);

        //    if (errorNumber.Length > 0)
        //    {
        //        return new ValidationResult(errorNumber, localizationService.GetResource(errorNumber));
        //    }
        //    return ValidationResult.Success;
        //}

        //public LoginValidationResult Login(string usernameOrEmail, string password)
        //{
        //    var result = new LoginValidationResult() { LoginSucceeded = false };

        //    var user =
        //        repository.DbSet<EfUser>()
        //            .SingleOrDefault(
        //                a =>
        //                    (a.Username == usernameOrEmail || a.EmailID == usernameOrEmail) &&
        //                    a.AuthenticationType == (int)UserAuthenticationType.UsernamePassword);

        //    if (user != null)
        //    {
        //        string hashedPassword = encrService.EncryptText(password, SecretEncryptionKey); //encrService.CreatePasswordHash(password, user.UserPwdSalt);
        //        if (user.UserPwd == hashedPassword)
        //        {
        //            result.LoginSucceeded = true;
        //            result.UserId = user.Id;
        //            result.Username = user.Username;
        //        }
        //    }

        //    return result;
        //}

        //public CreateAccountValidationResult CreateAccount(string username, string email,
        //    UserAuthenticationType authenticationType, string externalAuthenticationId,
        //    bool hasCompletedCelebrityTwitterAuth)
        //{
        //    var validationResult = ValidateCreateAccountArgs(username, email);

        //    if (!validationResult.IsValid)
        //    {
        //        return validationResult;
        //    }

        //    //if everything valid, create the user
        //    var newUser = new EfUser()
        //    {
        //        Username = username,
        //        EmailID = email,
        //        CreatedOn = DateTime.UtcNow,
        //        IsActive = true,
        //        AuthenticationType = (int)authenticationType,
        //        ExternalAuthenticationId = externalAuthenticationId,
        //        IsCelebrity = hasCompletedCelebrityTwitterAuth,
        //        RoleID = (int)Zing.Model.Role.AppUser
        //    };
        //    // Added on 30-jan-2015 for Facebook & Twitter create account issue
        //    //start
        //    if (newUser.UserPwd == null)
        //        newUser.UserPwd = "";
        //    if (newUser.UserPwdSalt == null)
        //        newUser.UserPwdSalt = "";
        //    //end  
        //    repository.Add(newUser);
        //    validationResult.UserId = newUser.Id;

        //    return validationResult;
        //}

        //public CreateAccountValidationResult CreateAccount(string username, string email, string password)
        //{
        //    var validationResult = ValidateCreateAccountArgs(username, email, password);

        //    if (!validationResult.IsValid)
        //    {
        //        return validationResult;
        //    }

        //    //if everything valid, create the user
        //    var newUser = new EfUser()
        //    {
        //        Username = username,
        //        EmailID = email,
        //        CreatedOn = DateTime.UtcNow,
        //        IsActive = true,
        //        AuthenticationType = (int)UserAuthenticationType.UsernamePassword,
        //        RoleID = (int)Zing.Model.Role.AppUser
        //    };

        //    var encryptedPassword = encrService.EncryptText(password, SecretEncryptionKey);
        //    var salt = "";
        //    newUser.UserPwd = encryptedPassword;
        //    newUser.UserPwdSalt = salt;

        //    repository.Add(newUser);
        //    validationResult.UserId = newUser.Id;

        //    return validationResult;
        //}

        //private CreateAccountValidationResult ValidateCreateAccountArgs(string username, string email, string password = null)
        //{
        //    var validationResult = new CreateAccountValidationResult();

        //    //validate username is unique (ignoring case) among all usernames and emails.
        //    var usernameAlreadyExists =
        //        repository.GetQuery<EfUser>()
        //            .Any(a => a.Username == username || a.EmailID == username);
        //    if (usernameAlreadyExists)
        //    {
        //        validationResult.ValidationErrors.Add(CreateAccountValidationError.UsernameNotUnique);
        //    }

        //    //validate email is unique (ignoring case) among all usernames and emails.
        //    var emailAlreadyExists =
        //        repository.GetQuery<EfUser>()
        //            .Any(a => a.Username.ToLower() == email.ToLower() || a.EmailID.ToLower() == email.ToLower());
        //    if (emailAlreadyExists)
        //    {
        //        validationResult.ValidationErrors.Add(CreateAccountValidationError.EmailNotUnique);
        //    }

        //    //validate username fits requirements:
        //    //  1) must be between 5 and 30 characters. only alphanumerics, '.', and '_' are allowed.
        //    //  2) case insensitive when entering for login or forgot password purposes, 
        //    //      but case is stored when account is created.
        //    //  3) must pass profanity filter
        //    var usernameValid = Regex.IsMatch(username, @"^([a-zA-Z\d\._]){5,30}$");
        //    if (!usernameValid)
        //    {
        //        validationResult.ValidationErrors.Add(CreateAccountValidationError.UsernameNotValid);
        //    }

        //    //validate username is not profane
        //    var usernameProfane = profanityCheckService.CheckProfanity(username);
        //    if (usernameProfane)
        //    {
        //        validationResult.ValidationErrors.Add(CreateAccountValidationError.UsernameProfane);
        //    }

        //    //validate email fits requirements:
        //    //  1) basic sanity check
        //    var emailValid = Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        //    if (!emailValid)
        //    {
        //        validationResult.ValidationErrors.Add(CreateAccountValidationError.EmailNotValid);
        //    }

        //    //validate password fits requirements:
        //    //  1)  between 7 and 20 characters. 
        //    //  2)  cannot contain spaces. 
        //    //  3)  must have at least one number and at least one letter. 
        //    if (!string.IsNullOrEmpty(password))
        //    {
        //        var passwordValid = IsPasswordValid(password);
        //        if (!passwordValid)
        //        {
        //            validationResult.ValidationErrors.Add(CreateAccountValidationError.PasswordNotValid);
        //        }
        //    }
        //    return validationResult;
        //}

        public static bool IsPasswordValid(string password)
        {
            //validate password fits requirements:
            //  1)  between 7 and 20 characters. 
            //  2)  cannot contain spaces. 
            //  3)  must have at least one number and at least one letter.
            bool passwordValid = false;
            if (!string.IsNullOrWhiteSpace(password))
            {
                passwordValid = Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-zA-Z])(?!.*\s).{7,20}$");
            }
            return passwordValid;
        }



        //public LoginValidationResult ExternalLogin(UserAuthenticationType authenticationType,
        //    string externalAuthenticationId)
        //{
        //    var result = new LoginValidationResult();
        //    var user =
        //        repository.DbSet<EfUser>()
        //            .SingleOrDefault(
        //                a => a.ExternalAuthenticationId == externalAuthenticationId &&
        //                    a.AuthenticationType == (int)authenticationType);

        //    result.LoginSucceeded = user != null;
        //    result.UserId = user == null ? 0 : user.Id;
        //    result.Username = user == null ? "" : user.Username;

        //    return result;
        //}


        //public bool SendForgottenPassword(string usernameOrEmail)
        //{
        //    var user = repository.List<User>().SingleOrDefault(
        //            a => a.IsActive && (a.Username == usernameOrEmail || a.EmailID == usernameOrEmail));

        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var emailAddress = user.EmailID;
        //        var encryptedPassword = user.UserPwd;
        //        //var decryptedPassword = encrService.DecryptText(encryptedPassword, SecretEncryptionKey);
        //        string emailBody = "Dear " + user.Username + ",<br/><br/>";
        //        //emailBody = emailBody + "Your zing password: " + decryptedPassword;
        //        //emailSender.TempGenecaSendEmail(emailAddress, "Here's your Zing password", emailBody);
        //        //emailSender.TempGenecaSendEmail(emailAddress, "Here's your Zing password", decryptedPassword);

        //        return true;
        //    }
        //}



        /// <summary>
        /// To Validate given Device details.
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceToken"></param>
        /// <param name="DeviceRegisterID"></param>
        /// <returns></returns>
        public ValidationResult ValidateUserDevice(DeviceType deviceType, string deviceToken, string deviceRegisterID)
        {
            // Validation of Device Register ID for Android devices.
            if (!string.IsNullOrEmpty(deviceToken) && deviceType == DeviceType.Android && string.IsNullOrEmpty(deviceRegisterID))
            {
                return new ValidationResult(ErrorCodes.SigninError, localizationService.GetResource("InvalidDeviceRegisterID"));
            }

            return ValidationResult.Success;
        }


        /// <summary>
        /// To Update Login User Device Details.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceSnsARN"></param>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        //public ValidationResult UpdateLoginDeviceDetails(long userID, DeviceType deviceType, string deviceToken, string deviceSnsARN, string deviceID)
        //{
        //    string errorNumber = string.Empty;

        //    // For iOS/Android Devices.
        //    if (!string.IsNullOrEmpty(deviceToken))
        //    {
        //        // Checking for DeviceToken existence.
        //        var deviceSNS = repository.FindOne<EfDeviceSnsARN>(
        //                         u => u.DeviceToken == deviceToken && u.DeviceTypeID == deviceType);

        //        if (deviceSNS != null && deviceSNS.SnsARN != null)
        //        {
        //            deviceSnsARN = deviceSNS.SnsARN.Trim();
        //        }
        //        else
        //        {
        //            //Create ARN for iOS Devices.
        //            SNSPushService pushService = (SNSPushService)pushBroker.GetRegistrations<SNSNotification>().FirstOrDefault();
        //            if (pushService != null)
        //            {
        //                string snsARN = pushService.RegisterDevice(deviceToken, (short)deviceType);
        //                deviceSnsARN = snsARN;
        //            }
        //        }
        //    }

        //    // Getting Current User Device details.
        //    var userDevice = repository.FindOne<EfDeviceUser>(
        //                     u => u.UserID == userID && u.DeviceType == deviceType);

        //    if (userDevice != null && userDevice.DeviceToken == deviceToken && userDevice.SnsARN == deviceSnsARN && userDevice.DeviceIdentifier == deviceID)
        //    {
        //        // No update required now.
        //    }
        //    else
        //    {
        //        User user = new User
        //        {
        //            UserId = userID,
        //            DeviceTypeID = (short)deviceType,
        //            DeviceToken = deviceToken,
        //            SnsARN = deviceSnsARN,
        //            DeviceID = deviceID
        //        };

        //        // Update login device details in database.
        //        userDataService.SetDeviceUser(user, out errorNumber);

        //        if (errorNumber.Length > 0)
        //        {
        //            return new ValidationResult(errorNumber, localizationService.GetResource(errorNumber));
        //        }
        //    }

        //    return ValidationResult.Success;
        //}
        /// <summary>
        /// To Update User Last Login Details.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="authenticationType"></param>
        /// <param name="deviceToken"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public ValidationResult UpdateLoginUserDetails(string userID, UserAuthenticationType authenticationType, string deviceToken, DeviceType deviceType)
        {
            // Checking for existing user login data.
            //var loginDetails = repository.FindOne<EfUserLogin>(ul => ul.UserID == userID);

            //if (loginDetails != null)
            //{
            //    loginDetails.LoginTypeID = (int)authenticationType;
            //    loginDetails.LoginToken = deviceToken;
            //    loginDetails.LastLogin = DateTime.UtcNow;
            //    loginDetails.LastLogOut = null;
            //    loginDetails.DeviceTypeID = deviceType;

            //    repository.Update(loginDetails);
            //}
            //else
            //{
            //    var userLogin = new EfUserLogin()
            //    {
            //        UserID = userID,
            //        LoginTypeID = (int)authenticationType,
            //        LoginToken = deviceToken,
            //        LastLogin = DateTime.UtcNow,
            //        LastLogOut = null,
            //        DeviceTypeID = deviceType
            //    };
            //    repository.Add(userLogin);
            //}

            return ValidationResult.Success;
        }

        ///// <summary>
        ///// To Logout a user from a Device.
        ///// </summary>
        ///// <param name="userID"></param>
        ///// <returns></returns>
        public ValidationResult LogoutDeviceUser(string userID)
        {
            string errorNumber = string.Empty;

            if (!String.IsNullOrEmpty(userID))
            {
                return new ValidationResult(ErrorCodes.ValidationError, localizationService.GetResource("InvalidData"));
            }

            // Updating in DB against an App User.
            //userDataService.LogoutDeviceUser(userID, out errorNumber);

            if (errorNumber.Length > 0)
            {
                return new ValidationResult(errorNumber, localizationService.GetResource(errorNumber));
            }

            return ValidationResult.Success;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// To get Registration mail content
        /// </summary>
        /// <param name="user">User details</param>
        /// <returns>mail content</returns>
        //private string GetUserRegistrationEmailContent(User user)
        //{
        //    string mailContent = localizationService.GetResource("UserRegistrationMailTemplate");
        //    if (user.Role == Zing.Model.Role.BroadcasterAdmin)
        //    {
        //        mailContent = mailContent.Replace("[UserFullName]", user.FullName.Trim())
        //            .Replace("[UserName]", user.Username)
        //            .Replace("[Password]", user.UserPwd)
        //            .Replace("[webUrl]", applicationSettings.WebUrl)
        //            .Replace("[MessageText]", "You have successfully registered an account in Zing with the following credentials.");
        //        return mailContent;
        //    }
        //    else if (user.Role == Zing.Model.Role.AppUser)
        //    {
        //        mailContent = mailContent.Replace("[UserFullName]", string.Empty)
        //            .Replace("Hello ", "Hello")
        //            .Replace("[UserName]", user.Username)
        //            .Replace("[Password]", user.UserPwd)
        //            .Replace("Please login to your account by browsing the following link :", "")
        //            .Replace("[webUrl]", "")
        //            .Replace("click here", "")
        //            .Replace("[MessageText]", "You have successfully registered an account in Zing with the following credentials.");
        //        return mailContent;
        //    }
        //    return mailContent;
        //}

        /// <summary>
        /// To Send Notification Email to newly registered users.
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="invitedByUser"></param>
        /// <param name="groupName"></param>
        //private void UserRegisterNotificationMail(string emailID, string loginEmail, string loginPassword)
        //{
        //    string emailSubject = "You have successfully registered an account in Zing.";

        //    string emailBody = "Hi, <br/><br/>" +
        //                    "You have successfully registered an account on Zing with the following credentials. <br/><br/>" +
        //                    "Login Email: " + loginEmail.Trim() + "<br/>" +
        //                    "Login Password: " + loginPassword.Trim() + "<br/><br/>" +
        //                    "Best regards,<br/>" +
        //                    "Zing Support Team";

        //    IEmailSender sender = new SESEmailSender(awsSettings);
        //    sender.SendEmail(new EmailAccount() { }, emailSubject, emailBody, new MailAddress("zinginformation@gmail.com"), new MailAddress(emailID), null, null, null, null);
        //}


        #endregion

    }
}
