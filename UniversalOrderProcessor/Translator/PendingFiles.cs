using System;
using System.Collections.Generic;

namespace Translator
{
    public class PendingFiles : IPendingFiles
    {
        IList<IIncomingFile> IPendingFiles.GetFiles()
        {
            throw new NotImplementedException();
        }
    }
}