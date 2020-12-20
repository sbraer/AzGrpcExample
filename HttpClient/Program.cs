using System;
using System.Net;
using System.Threading.Tasks;

namespace HttpClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
#if (DEBUG)
			int counter = 10;
#else
			int counter = 9999999;
#endif
			string serverName = Environment.GetEnvironmentVariable("SERVER_NAME") ?? "http://localhost:54645/weatherforecast";

			using var client = new WebClient();
			for (int i = 0; i < counter; i++)
			{
				try
				{
					string reply = await client.DownloadStringTaskAsync(serverName);
					Console.WriteLine($"{i}: {reply.Length} - OK");
				}
				catch(Exception ex)
				{
					Console.WriteLine($"{i}: {ex.Message} - ERROR");
				}

				await Task.Delay(500);
			}
		}
	}
}
