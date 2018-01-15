using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.ForeignOrderFormats
{
    public class Unknown : IForeignFormat
    {
        public Unknown()
        {

        }
        public string Name => throw new NotImplementedException();

        public void MarkFailedOnTransaltion()
        {
            throw new NotImplementedException();
        }

        public void MarkSuccessfullyTranslated()
        {
            throw new NotImplementedException();
        }

        public INativeFormat Translate()
        {
            throw new NotImplementedException();
        }
    }
}
