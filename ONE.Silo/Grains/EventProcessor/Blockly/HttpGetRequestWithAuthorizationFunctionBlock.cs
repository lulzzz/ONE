using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_function_http_get_request_with_authentication")]
    public class HttpGetRequestWithAuthorizationFunctionBlock : ONEConfigurationOutputBlock<string>
    {
        [BlocklyConfigurationValueInfo(ValueName = "endPoint")]
        public ONEConfigurationOutputBlock<string> EndPoint { get; set; }

        [BlocklyConfigurationValueInfo(ValueName = "param")]
        public ONEConfigurationOutputBlock<string> Param { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "returnType")]
        public string ReturnType { get; set; }
        [BlocklyConfigurationValueInfo(ValueName = "authenticationType")]
        public ONEConfigurationOutputBlock<HttpAuthenticationInfo> httpAuthenticationInfo { get; set; }

        public override async Task<string> GetOutput()
        {

            HttpAuthenticationInfo httpAuthentication = await httpAuthenticationInfo.GetOutput();

            string httpResponseMessage = string.Empty;
            try
            {
                string url = await EndPoint.GetOutput();
                string parameter = await Param.GetOutput();
                if (!string.IsNullOrEmpty(parameter))
                {
                    url = url + "?" + parameter;
                }

                //Set security protocol for https calls.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";

                //Add authentication header if necessary
                if (httpAuthentication.httpAuthenticationType == HttpAuthenticationType.UsernamePassword)
                {
                    string usernamePassword = httpAuthentication.Username + ':' + httpAuthentication.Password;
                    string base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(usernamePassword));
                    string authenticationHeader = $"Authorization: Basic {base64EncodedAuthenticationString}";
                    request.Headers.Add(authenticationHeader);
                }


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        httpResponseMessage = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return "Unauthorized";
                }

            }
            return httpResponseMessage;
        }
    }
}
