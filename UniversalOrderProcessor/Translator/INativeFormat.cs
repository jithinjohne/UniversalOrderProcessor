using System.Collections.Generic;

namespace Translator
{
    public interface INativeFormat
    {
        INativeFormat PrintFrom(string fileContent);
        string FileContent();
    }
}