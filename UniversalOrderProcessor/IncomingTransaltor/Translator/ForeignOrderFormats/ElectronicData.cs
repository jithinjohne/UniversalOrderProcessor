using System;

namespace Translator.ForeignOrderFormats
{
    public class ElectronicData : ForeignFormat, IForeignFormat
    {
        public ElectronicData(IApplicationSettings applicationSettings, string fileName, ILogger logger)
            : base(applicationSettings, fileName, logger)
        {
        }

        public INativeFormat Translate()
        {
            throw new NotImplementedException();
        }
    }
}