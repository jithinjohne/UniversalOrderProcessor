namespace Translator.ForeignOrderFormats
{
    public class Invoice : ForeignFormat, IForeignFormat
    {
        public Invoice(string fileName, IFileSystem fileSystem)
            : base(fileName, fileSystem)
        {
        }

        public INativeFormat Translate()
        {
            throw new System.NotImplementedException();
        }
    }
}