using System;

namespace AzGrpcService
{
    public interface IHelper
    {
        string ProcessId { get; }
        int Counter {get;set;}
    }

    public class Helper : IHelper
    {
        public string ProcessId { get; protected set; }
        public int Counter {get;set;}
        public Helper()
        {
            ProcessId = Guid.NewGuid().ToString();
            Counter = 0;
        }
    }
}