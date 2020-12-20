using System;

namespace HttpService
{
	public interface IHelper
	{
		int Counter { get; set; }
		bool RandomError { get; init; }
	}

	public class Helper : IHelper
	{
		public int Counter { get; set; }
		public bool RandomError { get; init; }

		public Helper()
		{
			Counter = 0;
			RandomError = bool.Parse(Environment.GetEnvironmentVariable("RANDOM_ERROR") ?? "false");
		}
	}
}
