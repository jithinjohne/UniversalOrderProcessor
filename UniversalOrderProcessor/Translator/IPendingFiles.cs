using System.Collections.Generic;

namespace Translator
{
    public interface IPendingFiles
    {
        IEnumerable<IIncomingFile> GetAll();
    }
}