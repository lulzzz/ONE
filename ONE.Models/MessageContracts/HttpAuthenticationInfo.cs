using ONE.Models.Enumerations;

namespace ONE.Models.MessageContracts
{
    public class HttpAuthenticationInfo
    {
        public HttpAuthenticationType httpAuthenticationType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
