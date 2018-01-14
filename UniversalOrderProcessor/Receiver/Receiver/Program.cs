using NLog;
using OrderSource;

namespace Receiver
{
    internal class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            var orderSources = new AllOrderSources();
            orderSources.Receive();
        }
    }
}