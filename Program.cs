try
{
    var client = new HttpClient();
    var responseBody = await client.GetStringAsync("http://127.0.0.1:52126");
    Console.WriteLine(responseBody);
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}
