using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Translator
{
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

            fileCountLimit = applicationSettings.ParallelFileProcessLimit;
        }

        public string GetFileNameWithExtension(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public IEnumerable<string> GetPendingFiles()
        {
            return Directory.GetFiles(pendingFilesLocation).Take(fileCountLimit);
        }

        public void MarkFileAsUnknown(string filePath)
        {
            File.Move(filePath, GetNewFileNameWithFullPath(unknownFilesLocation, filePath));
        }

        private string GetNewFileNameWithFullPath(string filePath, string fileName) => Path.Combine(filePath, RandomFileName(GetFileNameWithExtension(fileName)));

        public string ReadFile(string fileName)
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

        public void MarkAsFailedOnTransaltion(string fullFilePath)
        {
            File.Move(fullFilePath, GetNewFileNameWithFullPath(errorFileLocaiton, fullFilePath));
        }

        public void MarkAsSuccessfullyTranslated(string fullFilePath)
        {
            File.Move(fullFilePath, GetNewFileNameWithFullPath(successFileLocation, fullFilePath));
        }
    }
}