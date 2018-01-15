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
        public int PendingFilesProcessLimit => 10;

        /// <summary>
        /// Gets the error file path.
        /// </summary>
        public string ErrorFilePath => "Error";

        /// <summary>
        /// Gets the success file path.
        /// </summary>
        public string SuccessFilePath => "Success";

        /// <summary>
        /// Gets the base file path.
        /// </summary>
        public string BaseFilePath => @"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\IncomingTranslator";

        /// <summary>
        /// Gets the pending files location.
        /// </summary>
        public string PendingFilesLocation => "Pending";

        /// <summary>
        /// Gets the unknown files location.
        /// </summary>
        public string UnknownFilesLocation => "Unknown";

        /// <summary>
        /// Gets the shipment name <see cref="Regex" /> pattern.
        /// </summary>
        public string ShipmentNamePattern => "^NAVASN.*$";

        /// <summary>
        /// Gets the invoice name <see cref="Regex" /> pattern.
        /// </summary>
        public string InvoiceNamePattern => "^NAVINV.*$";

        /// <summary>
        /// Gets the acknowledgement name <see cref="Regex" /> pattern.
        /// </summary>
        public string AcknowledgementNamePattern => "^NAVACK.*$";

        /// <summary>
        /// Gets the electronic data name <see cref="Regex" /> pattern.
        /// </summary>
        public string ElectronicDataNamePattern => "^NAVEDI.*$";
    }
}