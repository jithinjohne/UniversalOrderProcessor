using System.Configuration;
using System.Globalization;

namespace Translator
{
    /// <summary>
    /// Application settings
    /// </summary>
    /// <seealso cref="Translator.IApplicationSettings" />
    public class ApplicationSettings : IApplicationSettings
    {
        /// <summary>
        /// Gets the count of pending files to process at a time.
        /// </summary>
        public int PendingFilesProcessLimit => int.Parse(ConfigurationManager.AppSettings["PendingFilesProcessLimit"], CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the error file path.
        /// </summary>
        public string ErrorFilePath => ConfigurationManager.AppSettings["ErrorFilePath"];

        /// <summary>
        /// Gets the success file path.
        /// </summary>
        public string SuccessFilePath => ConfigurationManager.AppSettings["SuccessFilePath"];

        /// <summary>
        /// Gets the base file path.
        /// </summary>
        public string BaseFilePath => ConfigurationManager.AppSettings["BaseFilePath"];

        /// <summary>
        /// Gets the pending files location.
        /// </summary>
        public string PendingFilesLocation => ConfigurationManager.AppSettings["PendingFilesLocation"];

        /// <summary>
        /// Gets the unknown files location.
        /// </summary>
        public string UnknownFilesLocation => ConfigurationManager.AppSettings["UnknownFilesLocation"];

        /// <summary>
        /// Gets the shipment name <see cref="Regex" /> pattern.
        /// </summary>
        public string ShipmentNamePattern => ConfigurationManager.AppSettings["ShipmentNamePattern"];

        /// <summary>
        /// Gets the invoice name <see cref="Regex" /> pattern.
        /// </summary>
        public string InvoiceNamePattern => ConfigurationManager.AppSettings["InvoiceNamePattern"];

        /// <summary>
        /// Gets the acknowledgment name <see cref="Regex" /> pattern.
        /// </summary>
        public string AcknowledgmentNamePattern => ConfigurationManager.AppSettings["AcknowledgmentNamePattern"];

        /// <summary>
        /// Gets the electronic data name <see cref="Regex" /> pattern.
        /// </summary>
        public string ElectronicDataNamePattern => ConfigurationManager.AppSettings["ElectronicDataNamePattern"];
    }
}