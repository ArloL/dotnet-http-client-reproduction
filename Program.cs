using System.Net.Sockets;
using System.Text;

try
{
    string host = "127.0.0.1";
    int port = 52126;
    string endpoint = "/";

    var httpClient = new HttpClient();
    var responseBody = await httpClient.GetStringAsync("http://" + host + ":" + port + endpoint);
    Console.WriteLine(responseBody);

    using (var client = new TcpClient(host, port))
    {
        using (var networkStream = client.GetStream())
        {
            // Prepare the HTTP GET request
            string request = $"GET {endpoint} HTTP/1.1\r\n" +
                                $"Host: {host}\r\n" +
                                "Connection: close\r\n" +
                                "\r\n";
            byte[] requestBytes = Encoding.ASCII.GetBytes(request);

            // Send the HTTP request
            networkStream.Write(requestBytes, 0, requestBytes.Length);

            // Read the server response
            byte[] buffer = new byte[4096];
            int bytesRead;
            StringBuilder responseBuilder = new StringBuilder();

            while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string responsePart = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                responseBuilder.Append(responsePart);
            }

            // Output the response
            Console.WriteLine("Server Response:");
            Console.WriteLine(responseBuilder.ToString());
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
