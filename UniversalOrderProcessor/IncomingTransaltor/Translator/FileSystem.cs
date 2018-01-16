using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ILogger logger;

        private static string RandomFileName(string context) => $"{context}_{DateTime.Now.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture)}_{Guid.NewGuid().ToString("N")}";

        public FileSystem(IApplicationSettings applicationSettings, ILogger logger)
        {
            var baseFilePath = applicationSettings.BaseFilePath;
            pendingFilesLocation = Path.Combine(baseFilePath, applicationSettings.PendingFilesLocation);
            unknownFilesLocation = Path.Combine(baseFilePath, applicationSettings.UnknownFilesLocation);
            errorFileLocaiton = Path.Combine(baseFilePath, applicationSettings.ErrorFilePath);
            successFileLocation = Path.Combine(baseFilePath, applicationSettings.SuccessFilePath);

            fileCountLimit = applicationSettings.PendingFilesProcessLimit;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the file name with extension.
        /// </summary>
        /// <param name="fullFilePath">The file path.</param>
        /// <returns></returns>
        public string GetFileNameWithExtension(string fullFilePath)
        {
            return Path.GetFileName(fullFilePath);
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
        /// <param name="fullFilePath">The file path.</param>
        public void MarkFileAsUnknown(string fullFilePath)
        {
            string destFileName = GetNewFileNameWithFullPath(unknownFilesLocation, fullFilePath);
            File.Move(fullFilePath, destFileName);

            logger.Warning($"Unknown file was moved");
            logger.Warning($"Source : {fullFilePath}");
            logger.Warning($"Destination : {destFileName}");
        }

        private string GetNewFileNameWithFullPath(string filePath, string fileName) => Path.Combine(filePath, RandomFileName(GetFileNameWithExtension(fileName)));

        /// <summary>
        /// Reads the content of the file.
        /// </summary>
        /// <param name="fullFilePath">Name of the file.</param>
        /// <returns></returns>
        public string ReadFileContent(string fullFilePath)
        {
            var fileContent = string.Empty;
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                using (StreamReader sr = new StreamReader(fileStream))
                {
                    fileStream = null;
                    fileContent = sr.ReadToEnd();
                    sr.Close();
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Dispose();
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