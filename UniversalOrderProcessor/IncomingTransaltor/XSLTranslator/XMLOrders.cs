using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XSLTranslator
{
    public class XMLOrders : ITranslatable
    {
        private const string searchPattern = "*-cc.xml";
        private const string path = @"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\IncomingTranslator";
        private DirectoryInfo directoryInfo;

        public XMLOrders()
        {
            directoryInfo = new DirectoryInfo(path);
        }

        public void Translate()
        {
            var file = directoryInfo.GetFiles().First();
            //Todo : Add file translate logic using XSLT
        }
    }
}