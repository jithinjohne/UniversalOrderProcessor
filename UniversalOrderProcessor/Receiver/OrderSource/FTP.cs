using NLog;
using System.IO;

namespace OrderSource
{
    /// <summary>
    /// Order coming through FTP
    /// </summary>
    public class FTP : IMovable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Move()
        {
            var sourceLocation = Path.GetFullPath(@"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\Receiver\Order-CC.xml");
            var destinationLocation = Path.GetFullPath(@"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\IncomingTranslator\Order-CC.xml");
            File.Move(sourceLocation, destinationLocation);

            logger.Info($"1 Order file copied from {sourceLocation} to {destinationLocation}");
        }
    }
}