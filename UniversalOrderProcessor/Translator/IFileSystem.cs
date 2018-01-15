namespace Translator
{
    public interface IFileSystem
    {
        string ReadFile(string fileName);
        string GetFileNameWithExtension(string filePath);
        void MarkFileAsUnknown(string file);
    }
}