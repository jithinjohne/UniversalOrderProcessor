using System;

namespace Translator.ForeignOrderFormats
{
    public class Acknowledgment : ForeignFormat, IForeignFormat
    {
        private readonly string fileName;

        public Acknowledgment(IApplicationSettings applicationSettings, string fileName, ILogger logger)
            : base(applicationSettings, fileName, logger)
        {
            this.fileName = fileName;
        }

        public string Name => fileName;

        public INativeFormat Translate()
        {
            throw new NotImplementedException();
        }
    }
}