using System;

namespace AzGrpcService
{
    public interface IHelper
    {
        string ProcessId { get; }
        int Counter {get;set;}
        bool RandomError {get; init;}
    }

    public class Helper : IHelper
    {
        public string ProcessId { get; protected set; }
        public int Counter {get;set;}
        public bool RandomError {get; init;}
        public Helper()
        {
            ProcessId = Guid.NewGuid().ToString();
            Counter = 0;
            RandomError = bool.Parse(Environment.GetEnvironmentVariable("RANDOM_ERROR") ?? "false");
        }
    }
}