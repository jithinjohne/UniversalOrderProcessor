using System.Linq;

namespace Translator.ForeignOrderFormats
{
    public class Acknowledgment : ForeignFormat, IForeignFormat
    {
        private readonly INativeFormat nativeFormat;
        private readonly IOperatingSystem file;
        private readonly string fileName;

        public Acknowledgment(IApplicationSettings applicationSettings, string fileName, ILogger logger, IOperatingSystem file, INativeFormat nativeFormat)
            : base(applicationSettings, fileName, logger)
        {
            this.fileName = fileName;
            this.file = file;
            this.nativeFormat = nativeFormat;
        }

        public INativeFormat Translate()
        {
            return nativeFormat.PrintFrom(Format(file.ReadFile(fileName)));
        }

        private string Format(string fileContent)
        {
            return new string(fileContent.Take(100).ToArray());
        }
    }
}