// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Net.Http;
// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
namespace api_http_test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await api_list_id();

            var server = new MyHttpServer(new string[] { "http://127.0.0.1:5000/" });
            await server.StartAsync();
        }

        static async Task api_list_id()
        {
            var client = new HttpClient();
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://hust.media/dc.php");
                response.EnsureSuccessStatusCode();
                //return;
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}


//using System;

//namespace MyApp // Note: actual namespace depends on the project name.
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}