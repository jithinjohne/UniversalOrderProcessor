using System.Collections.Generic;
using System.IO;

namespace XSLTranslator
{
    public interface IFileList
    {
        IEnumerable<FileInfo> GetOrders();
    }
}