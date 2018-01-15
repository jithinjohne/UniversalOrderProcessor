using System;

namespace Translator
{
    public class ApplicationSettings : IApplicationSettings
    {
        public int ParallelFileProcessLimit => 10;

        public string ErrorFilePath => "Error";

        public string SuccessFilePath => "Success";

        public string BaseFilePath => @"C:\Source\Projects\UniversalOrderProcessor\UniversalOrderProcessor\Tests\SampleProcessing\IncomingTranslator";

        public string PendingFilesLocation => "Pending";

        public string ShipmentNamePattern => "^NAVASN.*$";

        public string InvoiceNamePattern => "^NAVINV.*$";

        public string AcknowledgementNamePattern => "^NAVACK.*$";

        public string ElectronicDataNamePattern => "^NAVEDI.*$";

        public string UnknownFilesLocation => "Unknown";
    }
}