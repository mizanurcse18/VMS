using System.ComponentModel.DataAnnotations;
using PS.Model.Enums;

namespace PS.Web.UI.Models
{

    /// <summary>
    /// Models returned by AccountController actions.
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public DeviceType DeviceType { get; set; }          //// 1 - iPhone, 2 - Android
        [Required]
        public string DeviceID { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceRegisterID { get; set; }        //// For Android device register id in Google Cloud Messaging.
    }
}
