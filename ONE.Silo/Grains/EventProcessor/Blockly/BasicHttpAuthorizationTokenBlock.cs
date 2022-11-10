using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_token_username_password_authorization")]
    public class BasicHttpAuthorizationTokenBlock : ONEConfigurationOutputBlock<HttpAuthenticationInfo>
    {
        [BlocklyConfigurationValueInfo(ValueName = "username")]
        public ONEConfigurationOutputBlock<string> Username { get; set; }

        [BlocklyConfigurationValueInfo(ValueName = "password")]
        public ONEConfigurationOutputBlock<string> Password { get; set; }
        public override async Task<HttpAuthenticationInfo> GetOutput()
        {
            return new HttpAuthenticationInfo
            {
                httpAuthenticationType = HttpAuthenticationType.UsernamePassword,
                Username = await Username.GetOutput(),
                Password = await Password.GetOutput()
            };
        }
    }
}
