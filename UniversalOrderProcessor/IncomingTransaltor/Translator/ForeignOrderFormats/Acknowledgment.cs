using System.Linq;

namespace Translator.ForeignOrderFormats
{
    public class Acknowledgment : ForeignFormat, IForeignFormat
    {
        private readonly INativeFormat nativeFormat;
        private readonly IFileSystem fileSystem;
        private readonly string fileName;

        public Acknowledgment(string fileName, IFileSystem fileSystem, INativeFormat nativeFormat)
            : base(fileName, fileSystem)
        {
            this.fileName = fileName;
            this.fileSystem = fileSystem;
            this.nativeFormat = nativeFormat;
        }

        public INativeFormat Translate()
        {
            nativeFormat.LoadContentFrom(Format(fileSystem.ReadFileContent(fileName)));
            return nativeFormat;
        }

        private static string Format(string fileContent)
        {
            return new string(fileContent.Take(100).ToArray());
        }
    }
}