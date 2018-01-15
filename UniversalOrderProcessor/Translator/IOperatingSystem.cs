namespace Translator
{
    public interface IOperatingSystem
    {
        string ReadFile(string fileName);
        string GetFileNameWithExtension(string filePath);
        void MarkFileAsUnknown(string file);
    }
}