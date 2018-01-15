namespace Translator
{
    /// <summary>
    /// Native format file
    /// </summary>
    public interface INativeFormat
    {
        void LoadContentFrom(string fileContent);

        string FileContent();
    }
}