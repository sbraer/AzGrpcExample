using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace AzGrpcClient
{
	class Program
	{
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.GetMessageAsync(
                              new Message { Text = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Id + " " + reply.Text+ " " + reply.Counter);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
