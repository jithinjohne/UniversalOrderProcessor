namespace Translator.ForeignOrderFormats
{
    public class Invoice : ForeignFormat, IForeignFormat
    {
        public Invoice(IApplicationSettings applicationSettings, string fileName, ILogger logger)
            : base(applicationSettings, fileName, logger)
        {
        }

        public INativeFormat Translate()
        {
            throw new System.NotImplementedException();
        }
    }
}