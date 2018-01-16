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
        private readonly string shipmentNamePattern;
        private readonly string acknowledgementNamePattern;
        private readonly string electronicDataNamePattern;
        private readonly string invoiceNamePattern;

        public ForeignFileFactory(IFileSystem fileSystem, IApplicationSettings applicationSettings, ILogger logger, INativeFormat nativeFormat)
        {
            this.fileSystem = fileSystem;
            this.logger = logger;
            this.nativeFormat = nativeFormat;

            //Initialize name patterns from application settings.
            shipmentNamePattern = applicationSettings.ShipmentNamePattern;
            acknowledgementNamePattern = applicationSettings.AcknowledgmentNamePattern;
            electronicDataNamePattern = applicationSettings.ElectronicDataNamePattern;
            invoiceNamePattern = applicationSettings.InvoiceNamePattern;
        }

        /// <summary>
        /// Creates a foreign file.
        /// </summary>
        /// <returns></returns>
        public IForeignFormat CreateForeignFile(string fileFullPath)
        {
            var fileName = fileSystem.GetFileNameWithExtension(fileFullPath);
            if (ShipmentFile(fileName))
            {
                logger.Debug($"Shipment file created from {fileName}");
                return new ShipmentNotice(fileFullPath, fileSystem);
            }
            else if (AcknowledgmentFile(fileName))
            {
                logger.Debug($"Acknowledgment file created from {fileName}");
                return new Acknowledgment(fileFullPath, fileSystem, nativeFormat);
            }
            else if (ElectronicData(fileName))
            {
                logger.Debug($"ElectronicData file created from {fileName}");
                return new ElectronicData(fileFullPath, fileSystem);
            }
            else if (Invoice(fileName))
            {
                logger.Debug($"Invoice file created from {fileName}");
                return new Invoice(fileFullPath, fileSystem);
            }
            else
            {
                logger.Debug($"Unknown file type found {fileName}");
                return new Unknown();
            };
        }

        private bool AcknowledgmentFile(string fileName) => Match(acknowledgementNamePattern, fileName);

        private bool ShipmentFile(string fileName) => Match(shipmentNamePattern, fileName);

        private bool ElectronicData(string fileName) => Match(electronicDataNamePattern, fileName);

        private bool Invoice(string fileName) => Match(invoiceNamePattern, fileName);

        private static bool Match(string pattern, string fileName)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(fileName);
            return match.Success;
        }
    }
}