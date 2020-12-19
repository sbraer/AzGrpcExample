using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace AzGrpcClient
{
	class Program
	{
        static async Task Main(string[] args)
        {
            #if (DEBUG)
            int counter = 10;
            #else
            int counter = 99999;
            #endif

            string serverName = Environment.GetEnvironmentVariable("SERVER_NAME") ?? "http://localhost:5001";

            for (int i = 1; i < counter; i++)
            {
                try
                {
                    using var channel = GrpcChannel.ForAddress(serverName);
                    var client = new MyGrpcService.MyGrpcServiceClient(channel);
                    var reply = await client.GetMessageAsync( new Message { Text = $"Message {i}" });
                    Console.WriteLine("From service: " + reply.Id + " " + reply.Text+ " " + reply.Counter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                await Task.Delay(500);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
