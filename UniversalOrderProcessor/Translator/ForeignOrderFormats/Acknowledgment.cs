using System.Linq;

namespace Translator.ForeignOrderFormats
{
    public class Acknowledgment : ForeignFormat, IForeignFormat
    {
        private readonly INativeFormat nativeFormat;
        private readonly IFile file;
        private readonly string fileName;

        public Acknowledgment(IApplicationSettings applicationSettings, string fileName, ILogger logger, IFile file, INativeFormat nativeFormat)
            : base(applicationSettings, fileName, logger)
        {
            this.fileName = fileName;
            this.file = file;
            this.nativeFormat = nativeFormat;
        }

        public string Name => fileName;

        public INativeFormat Translate()
        {
            return nativeFormat.PrintFrom(Format(file.Read(fileName)));
        }

        private string Format(string fileContent)
        {
            return new string(fileContent.Take(100).ToArray());
        }
    }
}