using System.Text.RegularExpressions;
using Translator.ForeignOrderFormats;

namespace Translator
{
    /// <summary>
    /// Foreign file generator
    /// </summary>
    /// <seealso cref="Translator.IForeignFileFactory" />
    public class ForeignFileFactory : IForeignFileFactory
    {
        private readonly INativeFormat nativeFormat;
        private readonly ILogger logger;
        private readonly IFileSystem fileSystem;
        private readonly IApplicationSettings applicationSettings;
        private readonly string shipmentNamePattern;
        private readonly string acknowledgementNamePattern;
        private readonly string electronicDataNamePattern;
        private readonly string invoiceNamePattern;

        public ForeignFileFactory(IFileSystem fileSystem, IApplicationSettings applicationSettings, ILogger logger, INativeFormat nativeFormat)
        {
            this.fileSystem = fileSystem;
            this.applicationSettings = applicationSettings;
            this.logger = logger;
            this.nativeFormat = nativeFormat;

            //Initialize name patterns from application settings.
            shipmentNamePattern = applicationSettings.ShipmentNamePattern;
            acknowledgementNamePattern = applicationSettings.AcknowledgmentNamePattern;
            electronicDataNamePattern = applicationSettings.ElectronicDataNamePattern;
            invoiceNamePattern = applicationSettings.InvoiceNamePattern;
        }

        /// <summary>
        /// Creates the foreign file.
        /// </summary>
        /// <returns></returns>
        public IForeignFormat CreateForeignFile(string fullFilePath)
        {
            var fileName = fileSystem.GetFileNameWithExtension(fullFilePath);
            if (ShipmentFile(fileName))
            {
                return new ShipmentNotice(fullFilePath, fileSystem);
            }
            else if (AcknowledgmentFile(fileName))
            {
                return new Acknowledgment(fullFilePath, fileSystem, nativeFormat);
            }
            else if (ElectronicData(fileName))
            {
                return new ElectronicData(fullFilePath, fileSystem);
            }
            else if (Invoice(fileName))
            {
                return new Invoice(fullFilePath, fileSystem);
            }
            else
            {
                return new Unknown();
            };
        }

        private bool AcknowledgmentFile(string fileName) => Match(acknowledgementNamePattern, fileName);

        private bool ShipmentFile(string fileName) => Match(shipmentNamePattern, fileName);

        private bool ElectronicData(string fileName) => Match(electronicDataNamePattern, fileName);

        private bool Invoice(string fileName) => Match(invoiceNamePattern, fileName);

        private bool Match(string pattern, string fileName)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(fileName);
            return match.Success;
        }
    }
}