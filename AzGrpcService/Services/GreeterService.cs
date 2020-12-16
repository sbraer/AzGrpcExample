using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzGrpcService
{
	public class GreeterService : Greeter.GreeterBase
	{
		private readonly ILogger<GreeterService> _logger;
		private readonly IHelper _helper;

		public GreeterService(ILogger<GreeterService> logger, IHelper helper)
		{
			_logger = logger;
			_helper = helper;
		}

		public override Task<Reply> GetMessage(Message request, ServerCallContext context)
		{
			return Task.FromResult(new Reply
			{
				Id = _helper.ProcessId,
				Text="ciao",
				Counter=++_helper.Counter
			});
		}
	}
}
