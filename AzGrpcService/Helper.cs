using System;

namespace AzGrpcService
{
    public interface IHelper
    {
        string ProcessId { get; }
    }

    public class Helper : IHelper
    {
        public string ProcessId { get; protected set; }
        public Helper()
        {
            ProcessId = Guid.NewGuid().ToString();
        }
    }
}