using System;
using System.IO;

namespace Translator.ForeignOrderFormats
{
    public abstract class ForeignFormat
    {
        private readonly string fullFilePath;
        private readonly IFileSystem fileSystem;

        protected ForeignFormat(string fullFilePath, IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.fullFilePath = fullFilePath;
        }

        public string Name => fileSystem.GetFileNameWithExtension(fullFilePath);

        public void MarkFailedOnTransaltion()
        {
            fileSystem.MarkFileAsFailedOnTranslation(fullFilePath);
        }

        public void MarkSuccessfullyTranslated()
        {
            fileSystem.MarkFileAsSuccessfullyTranslated(fullFilePath);
        }
    }
}