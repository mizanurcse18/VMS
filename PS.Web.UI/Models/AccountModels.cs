using System.ComponentModel.DataAnnotations;
using PS.Framework.Filters;
using PS.Model;

namespace PS.Web.UI.Models
{
    /// <summary>
    /// Models returned by AccountController actions.
    /// </summary>
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string AdminId { get; set; }
        public Role RoleId { get; set; }
    }

    public class UserRegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string ReturnUrl { get; set; }
    }






    public class LoggedInUser
    {
        public LoggedInUser(long userId, string username)
        {
            this.UserName = username;
            this.UserId = userId;
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }

    public class ProfileEditModel
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string SecurityCode { get; set; }
        public string EmailId { get; set; }
        public string IsRegistered { get; set; }
        public string ShowSecurityCode { get; set; }

    }

    public class UserEditModel
    {
        public long UserId { get; set; }

        public string EmailID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string UserPwd { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Zip { get; set; }
        public string Gender { get; set; }
        public string AgeRange { get; set; }
        public string ProviderName { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class UserCreateModel
    {
        public long UserId { get; set; }

        public string EmailID { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }
        public string UserPwd { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Zip { get; set; }
        public string Gender { get; set; }
        public string AgeRange { get; set; }
        public string ProviderName { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }


    }

}