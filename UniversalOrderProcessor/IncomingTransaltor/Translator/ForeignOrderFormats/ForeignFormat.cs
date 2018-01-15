using System;
using System.IO;

namespace Translator.ForeignOrderFormats
{
    public abstract class ForeignFormat
    {
        private readonly string fileName;
        private readonly IFileSystem fileSystem;

        protected ForeignFormat(string fileName, IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.fileName = fileName;
        }

        public string Name => fileName;

        public void MarkFailedOnTransaltion()
        {
            fileSystem.MarkAsFailedOnTransaltion(fileName);
        }

        public void MarkSuccessfullyTranslated()
        {
            fileSystem.MarkAsSuccessfullyTranslated(fileName);
        }
    }
}