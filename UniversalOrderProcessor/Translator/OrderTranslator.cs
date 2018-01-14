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
            foreach (var file in incomingFiles)
            {
                file.
            }
        }
    }
}