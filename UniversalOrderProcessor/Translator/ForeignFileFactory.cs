using System;
using System.Text.RegularExpressions;
using Translator.ForeignOrderFormats;

namespace Translator
{
    public class ForeignFileFactory : IForeignFileFactory
    {
        private readonly INativeFormat nativeFormat;
        private readonly ILogger logger;
        private readonly IFileSystem file;
        private readonly IApplicationSettings applicationSettings;
        private readonly string shipmentNamePattern;
        private readonly string acknowledgementNamePattern;
        private readonly string electronicDataNamePattern;
        private readonly string invoiceNamePattern;

        public ForeignFileFactory(IFileSystem file, IApplicationSettings applicationSettings, ILogger logger, INativeFormat nativeFormat)
        {
            this.file = file;
            this.applicationSettings = applicationSettings;
            this.logger = logger;
            this.nativeFormat = nativeFormat;

            shipmentNamePattern = applicationSettings.ShipmentNamePattern;
            acknowledgementNamePattern = applicationSettings.AcknowledgementNamePattern;
            electronicDataNamePattern = applicationSettings.ElectronicDataNamePattern;
            invoiceNamePattern = applicationSettings.InvoiceNamePattern;
        }

        public IForeignFormat CreateForeignFile(string filePath)
        {
            var fileName = file.GetFileNameWithExtension(filePath);
            if (ShipmentFile(fileName))
            {
                return new ShipmentNotice(applicationSettings, fileName, logger);
            }
            else if (AcknowledgmentFile(fileName))
            {
                return new Acknowledgment(applicationSettings, fileName, logger, file, nativeFormat);
            }
            else if (ElectronicData(fileName))
            {
                return new ElectronicData(applicationSettings, fileName, logger);
            }
            else if (Invoice(fileName))
            {
                return new Invoice(applicationSettings, fileName, logger);
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