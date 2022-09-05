using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ONE.Common.Helpers
{
    public class NetworkHelper
    {
        private static readonly IPEndPoint DefaultLoopbackEndpoint = new(IPAddress.Loopback, port: 0);

        public static int GetAvailablePort(int? preferred = null)
        {
            if (preferred.HasValue && IsLocalPortAvailable(preferred.Value))
            {
                return preferred.Value;
            }

            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(DefaultLoopbackEndpoint);
            var localEndpoint = socket.LocalEndPoint as IPEndPoint;
            return localEndpoint?.Port ?? 0;
        }

        public static bool IsLocalPortAvailable(int port)
        {
            bool isAvailable = true;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in tcpConnInfoArray)
            {
                if (endpoint.Port == port)
                {
                    isAvailable = false;
                    break;
                }
            }

            return isAvailable;
        }
    }
}
