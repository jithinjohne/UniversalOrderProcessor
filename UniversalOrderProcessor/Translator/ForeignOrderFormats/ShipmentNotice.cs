namespace Translator.ForeignOrderFormats
{
    public class ShipmentNotice : ForeignFormat, IForeignFormat
    {
        public ShipmentNotice(IApplicationSettings applicationSettings, string fileName, ILogger logger )
            :base(applicationSettings, fileName, logger)
        {

        }

        public INativeFormat Translate()
        {
            throw new System.NotImplementedException();
        }
    }
}