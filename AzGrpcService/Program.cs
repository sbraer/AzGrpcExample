using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AzGrpcService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			string useCertificateString = Environment.GetEnvironmentVariable("USE_CERTIFICATE");
			bool useCertificate;
			if (bool.TryParse(useCertificateString, out bool value))
			{
				useCertificate = value;
			}
			else
			{
				useCertificate = false;
			}

			return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
						{
							if (useCertificate)
							{
								var serverCertificate = LoadCertificate();
								listenOptions.UseHttps(serverCertificate);
							}
							else
							{
								listenOptions.Protocols = HttpProtocols.Http2;
							}
						});
                    });
        
                    webBuilder.UseStartup<Startup>();
                });
		}

        private static X509Certificate2 LoadCertificate()
        {
			string certificatePfx = Environment.GetEnvironmentVariable("CERTIFICATE_PFX_File") ?? "domain.name.pfx";
			byte[] certificatePayload = File.ReadAllBytes(certificatePfx);
            return new X509Certificate2(certificatePayload, "123456");
        }
	}
}
