namespace Translator
{
    /// <summary>
    /// Native order
    /// </summary>
    /// <seealso cref="Translator.INativeFormat" />
    public class NativeOrder : INativeFormat
    {
        private const string Header = "<header>ABC corp</header>";
        private const string Footer = "<footer>summary</footer>";
        private string detail;

        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        /// <returns>
        /// File content in string format
        /// </returns>
        public string GetFileContent()
        {
            return $"{Header}{detail}{Footer}";
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="fileContent">Content of the file.</param>
        public void LoadContentFrom(string fileContent)
        {
            detail = fileContent;
        }
    }
}