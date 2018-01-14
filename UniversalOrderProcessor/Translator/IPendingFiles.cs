using System.Collections.Generic;

namespace Translator
{
    public interface IPendingFiles
    {
        IList<IIncomingFile> GetFiles();
    }
}