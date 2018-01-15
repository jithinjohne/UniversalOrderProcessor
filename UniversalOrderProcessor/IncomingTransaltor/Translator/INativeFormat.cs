namespace Translator
{
    /// <summary>
    /// Native format file
    /// </summary>
    public interface INativeFormat
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="fileContent">Content of the file.</param>
        void LoadContentFrom(string fileContent);

        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        /// <returns>File content in string format</returns>
        string GetFileContent();
    }
}