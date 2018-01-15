namespace Translator.ForeignOrderFormats
{
    public class ShipmentNotice : ForeignFormat, IForeignFormat
    {
        public ShipmentNotice(string fileName, IFileSystem fileSystem)
            : base(fileName, fileSystem)
        {
        }

        public INativeFormat Translate()
        {
            throw new System.NotImplementedException();
        }
    }
}