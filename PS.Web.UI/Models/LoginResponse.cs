using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.Api.Contracts.Responses
{
    /// <summary>
    /// Response class for User Login method
    /// </summary>
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        //public string EmailID { get; set; }
        public string ChatUsername { get; set; }
        public string ChatUserPwd { get; set; }
        public string XMPPServer { get; set; }
        public int XMPPPort { get; set; }
        public string AvatarURL { get; set; }
        public long ChannelDeviceID { get; set; }
    }
}
