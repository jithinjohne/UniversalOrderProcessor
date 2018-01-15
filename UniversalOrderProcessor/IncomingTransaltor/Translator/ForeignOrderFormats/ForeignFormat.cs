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

        private string ErrorFileName => Path.Combine(baseFilePath, errorFilePath, RandomFileName(fileName));
        private string SuccessFileName => Path.Combine(baseFilePath, successFilePath, RandomFileName(fileName));
        private string SourceFileName => Path.Combine(baseFilePath, fileName);

        private string RandomFileName(string context) => $"{context}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Guid.NewGuid().ToString("N")}";

        protected ForeignFormat(IApplicationSettings applicationSettings, string fileName, ILogger logger)
        {
            errorFilePath = applicationSettings.ErrorFilePath;
            successFilePath = applicationSettings.SuccessFilePath;
            baseFilePath = applicationSettings.BaseFilePath;
            this.fileName = fileName;
            this.logger = logger;
        }

        public string Name => fileName;

        public void MarkFailedOnTransaltion()
        {
            File.Move(SourceFileName, ErrorFileName);
        }

        public void MarkSuccessfullyTranslated()
        {
            File.Move(SourceFileName, SuccessFileName);
        }
    }
}