using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XSLTranslator
{
    public class XMLOrders : IFileList
    {
        private const string searchPattern = "*-cc.xml";
        private const string path = @"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\IncomingTranslator";
        private DirectoryInfo directoryInfo;

        public XMLOrders()
        {
            directoryInfo = new DirectoryInfo(path);
        }

        public IEnumerable<FileInfo> GetOrders()
        {
            return directoryInfo.GetFiles(searchPattern);
        }
    }
}