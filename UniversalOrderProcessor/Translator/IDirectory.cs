namespace Translator
{
    public interface IDirectory
    {
        string[] GetFiles(string pendingFilesLocation);
    }
}