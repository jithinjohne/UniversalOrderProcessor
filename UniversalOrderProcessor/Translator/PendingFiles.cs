using System;
using System.Collections.Generic;

namespace Translator
{
    public class PendingFiles : IPendingFiles
    {
        public IEnumerable<IIncomingFile> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}