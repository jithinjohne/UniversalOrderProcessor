using System.Collections.Generic;
using Translator.ForeignOrderFormats;

namespace Translator
{
    public interface IPendingFiles
    {
        IEnumerable<IForeignFormat> GetAll();
    }
}