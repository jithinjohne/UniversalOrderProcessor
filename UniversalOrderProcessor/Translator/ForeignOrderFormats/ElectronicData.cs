using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.ForeignOrderFormats
{
    public class ElectronicData : ForeignFormat, IForeignFormat
    {
        public ElectronicData(IApplicationSettings applicationSettings, string fileName, ILogger logger)
            : base(applicationSettings, fileName, logger)
        {

        }

        public INativeFormat Translate()
        {
            throw new NotImplementedException();
        }
    }
}
