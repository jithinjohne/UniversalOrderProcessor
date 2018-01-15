using System;
using System.IO;

namespace Translator.ForeignOrderFormats
{
    public abstract class ForeignFormat
    {
        private readonly ILogger logger;
        private readonly string fileName;
        private readonly string errorFilePath;
        private readonly string successFilePath;
        private readonly string baseFilePath;

        private string errorFileName => Path.Combine(baseFilePath, errorFilePath, RandomFileName(fileName));
        private string successFileName => Path.Combine(baseFilePath, successFilePath, RandomFileName(fileName));
        private string sourceFileName => Path.Combine(baseFilePath, fileName);

        private string RandomFileName(string context) => $"{context}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Guid.NewGuid().ToString("N")}";

        protected ForeignFormat(IApplicationSettings applicationSettings, string fileName, ILogger logger)
        {
            errorFilePath = applicationSettings.ErrorFilePath;
            successFilePath = applicationSettings.SuccessFilePath;
            baseFilePath = applicationSettings.BaseFilePath;
            this.fileName = fileName;
            this.logger = logger;
        }

        public void MarkFailedOnTransaltion()
        {
            File.Move(sourceFileName, errorFileName);
        }

        public void MarkSuccessfullyTranslated()
        {
            File.Move(sourceFileName, successFileName);
        }
    }
}