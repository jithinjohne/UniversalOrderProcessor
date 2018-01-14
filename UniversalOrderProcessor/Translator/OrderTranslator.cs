namespace Translator
{
    public class OrderTranslator
    {
        private IPendingFiles pendingFiles;

        public OrderTranslator(IPendingFiles pendingFiles)
        {
            this.pendingFiles = pendingFiles;
        }

        public void Translate()
        {
            var incomingFiles = pendingFiles.GetFiles();
            INativeOrder nativeOrder;
            foreach (var file in incomingFiles)
            {
                try
                {
                    nativeOrder = file.Translate();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}