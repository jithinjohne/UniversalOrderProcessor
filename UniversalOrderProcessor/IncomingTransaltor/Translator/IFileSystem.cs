using System.Collections.Generic;

namespace Translator
{
    public interface IFileSystem
    {
        string ReadFile(string fileName);

        string GetFileNameWithExtension(string filePath);

        void MarkFileAsUnknown(string file);
        IEnumerable<string> GetPendingFiles();
        void MarkAsFailedOnTransaltion(string fileName);
        void MarkAsSuccessfullyTranslated(string fileName);
    }
}