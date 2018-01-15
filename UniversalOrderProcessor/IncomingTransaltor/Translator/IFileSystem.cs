using System.Collections.Generic;

namespace Translator
{
    /// <summary>
    /// File and directory operation capabilities
    /// </summary>
    public interface IFileSystem
    {

        /// <summary>
        /// Reads the content of the file.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        /// <returns>File content as string</returns>
        string ReadFileContent(string fullFilePath);

        /// <summary>
        /// Gets the file name with extension.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        string GetFileNameWithExtension(string fullFilePath);

        /// <summary>
        /// Marks the file as unknown.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        void MarkFileAsUnknown(string fullFilePath);

        /// <summary>
        /// Gets the pending files.
        /// </summary>
        /// <returns>A collection of full file paths</returns>
        IEnumerable<string> GetPendingFiles();

        /// <summary>
        /// Marks the file as failed on translation.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        void MarkFileAsFailedOnTranslation(string fullFilePath);

        /// <summary>
        /// Marks the file as successfully translated.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        void MarkFileAsSuccessfullyTranslated(string fullFilePath);
    }
}