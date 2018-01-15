namespace Translator
{
    public interface IApplicationSettings
    {
        int ParallelFileProcessLimit { get; }
        string ErrorFilePath { get; }
        string SuccessFilePath { get; }
        string BaseFilePath { get; }
        string PendingFilesLocation { get; }
        string ShipmentNamePattern { get; }
        string InvoiceNamePattern { get; }
        string AcknowledgementNamePattern { get; }
        string ElectronicDataNamePattern { get; }
        string UnknownFilesLocation { get; }
    }
}