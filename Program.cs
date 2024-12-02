using System.Net;
using System.Net.Sockets;
using System.Text;

try
{
    string host = "127.0.0.1";
    int port = 52126;
    string endpoint = "/";

    var handler = new SocketsHttpHandler
    {
        ConnectCallback = async (context, token) =>
        {
            var endpoint = context.DnsEndPoint;
            Console.WriteLine($"Resolving IP for host: {endpoint.Host}");

            var ipAddresses = await Dns.GetHostAddressesAsync(endpoint.Host);
            foreach (var ip in ipAddresses)
            {
                Console.WriteLine($"Resolved IP: {ip}");
            }

            // Select the first IP (or implement your own logic for IP selection)
            var selectedIp = ipAddresses[0];
            Console.WriteLine($"Connecting to: {selectedIp}:{endpoint.Port}");

            // Establish the socket connection
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(selectedIp, endpoint.Port);

            Console.WriteLine($"Connected to {selectedIp}:{endpoint.Port} with dual mode {socket.DualMode}");
            return new NetworkStream(socket, ownsSocket: true);
        }
    };

    var httpClient = new HttpClient(handler);
    var responseBody = await httpClient.GetStringAsync("http://" + host + ":" + port + endpoint);
    Console.WriteLine(responseBody);
}
catch (Exception ex)
{
    Console.WriteLine($"Exception Type: {ex.GetType().Name}");
    Console.WriteLine($"Message: {ex.Message}");
    Console.WriteLine($"StackTrace: {ex.StackTrace}");
}
