using System;

namespace Translator.ForeignOrderFormats
{
    public class Unknown : IForeignFormat
    {
        public Unknown()
        {
        }

        public string Name => String.Empty;

        public void MarkFailedOnTranslation()
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