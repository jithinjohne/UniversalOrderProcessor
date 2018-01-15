using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class ApplicationSettings : IApplicationSettings
    {
        public int ParallelFileProcessLimit => throw new NotImplementedException();

        public string ErrorFilePath => throw new NotImplementedException();

        public string SuccessFilePath => throw new NotImplementedException();

        public string BaseFilePath => throw new NotImplementedException();

        public string PendingFilesLocation => throw new NotImplementedException();

        public string ShipmentNamePattern => "^NAVASN.*$";

        public string InvoiceNamePattern => throw new NotImplementedException();

        public string AcknowledgementNamePattern => throw new NotImplementedException();

        public string ElectronicDataNamePattern => throw new NotImplementedException();
    }
}
