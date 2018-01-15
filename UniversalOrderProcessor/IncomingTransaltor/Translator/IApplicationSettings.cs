using System.Text.RegularExpressions;

namespace Translator
{

    /// <summary>
    /// Application settings
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// Gets the count of pending files to process at a time.
        /// </summary>
        int PendingFilesProcessLimit { get; }
        
        /// <summary>
        /// Gets the error file path.
        /// </summary>
        string ErrorFilePath { get; }

        /// <summary>
        /// Gets the success file path.
        /// </summary>
        string SuccessFilePath { get; }

        /// <summary>
        /// Gets the base file path.
        /// </summary>
        string BaseFilePath { get; }

        /// <summary>
        /// Gets the pending files location.
        /// </summary>
        string PendingFilesLocation { get; }

        /// <summary>
        /// Gets the shipment name <see cref="Regex"/> pattern.
        /// </summary>
        string ShipmentNamePattern { get; }

        /// <summary>
        /// Gets the invoice name <see cref="Regex"/> pattern.
        /// </summary>
        string InvoiceNamePattern { get; }

        /// <summary>
        /// Gets the acknowledgement name <see cref="Regex"/> pattern.
        /// </summary>
        string AcknowledgementNamePattern { get; }

        /// <summary>
        /// Gets the electronic data name <see cref="Regex"/> pattern.
        /// </summary>
        string ElectronicDataNamePattern { get; }

        /// <summary>
        /// Gets the unknown files location.
        /// </summary>
        string UnknownFilesLocation { get; }
    }
}