using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Translator
{
    /// <summary>
    /// File and directory operations 
    /// </summary>
    /// <seealso cref="Translator.IFileSystem" />
    public class FileSystem : IFileSystem
    {
        private readonly string pendingFilesLocation;
        private readonly string unknownFilesLocation;
        private readonly string errorFileLocaiton;
        private readonly string successFileLocation;
        private readonly int fileCountLimit;

        private string RandomFileName(string context) => $"{context}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Guid.NewGuid().ToString("N")}";

        public FileSystem(IApplicationSettings applicationSettings)
        {
            var baseFilePath = applicationSettings.BaseFilePath;
            pendingFilesLocation = Path.Combine(baseFilePath, applicationSettings.PendingFilesLocation);
            unknownFilesLocation = Path.Combine(baseFilePath, applicationSettings.UnknownFilesLocation);
            errorFileLocaiton = Path.Combine(baseFilePath, applicationSettings.ErrorFilePath);
            successFileLocation = Path.Combine(baseFilePath, applicationSettings.SuccessFilePath);

            fileCountLimit = applicationSettings.PendingFilesProcessLimit;
        }

        /// <summary>
        /// Gets the file name with extension.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public string GetFileNameWithExtension(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        /// <summary>
        /// Gets the pending files.
        /// </summary>
        /// <returns>
        /// A collection of full file paths
        /// </returns>
        public IEnumerable<string> GetPendingFiles()
        {
            return Directory.GetFiles(pendingFilesLocation).Take(fileCountLimit);
        }

        /// <summary>
        /// Marks the file as unknown.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void MarkFileAsUnknown(string filePath)
        {
            File.Move(filePath, GetNewFileNameWithFullPath(unknownFilesLocation, filePath));
        }

        private string GetNewFileNameWithFullPath(string filePath, string fileName) => Path.Combine(filePath, RandomFileName(GetFileNameWithExtension(fileName)));

        /// <summary>
        /// Reads the content of the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public string ReadFileContent(string fileName)
        {
            var fileContent = string.Empty;

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    fileContent = sr.ReadToEnd();
                    sr.Close();
                }
            }

            return fileContent;
        }

        /// <summary>
        /// Marks the file as failed on translation.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        public void MarkFileAsFailedOnTranslation(string fullFilePath)
        {
            File.Move(fullFilePath, GetNewFileNameWithFullPath(errorFileLocaiton, fullFilePath));
        }

        /// <summary>
        /// Marks the file as successfully translated.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        public void MarkFileAsSuccessfullyTranslated(string fullFilePath)
        {
            File.Move(fullFilePath, GetNewFileNameWithFullPath(successFileLocation, fullFilePath));
        }
    }
}