using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzGrpcService
{
	public class AzService : MyGrpcService.MyGrpcServiceBase
	{
		private readonly ILogger<AzService> _logger;
		private readonly IHelper _helper;

		public AzService(ILogger<AzService> logger, IHelper helper)
		{
			_logger = logger;
			_helper = helper;
		}

		public override Task<Reply> GetMessage(Message request, ServerCallContext context)
		{
			_helper.Counter++;
			if (_helper.Counter % 2 == 0 && _helper.RandomError)
			{
				// https://grpc.io/docs/guides/error/
				//throw new RpcException(new Status(StatusCode.InvalidArgument, "Random Error"));
				throw new ArgumentException("Random Error");
			}
			else
			{
				return Task.FromResult(new Reply
				{
					Id = _helper.ProcessId,
					Text=request.Text,
					Counter=_helper.Counter
				});
			}
		}
	}
}
