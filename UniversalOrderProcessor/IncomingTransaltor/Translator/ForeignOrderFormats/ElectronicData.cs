using System;

namespace Translator.ForeignOrderFormats
{
    public class ElectronicData : ForeignFormat, IForeignFormat
    {
        public ElectronicData(string fileName, IFileSystem fileSystem)
            : base(fileName, fileSystem)
        {
        }

        public INativeFormat Translate()
        {
            throw new NotImplementedException();
        }
    }
}