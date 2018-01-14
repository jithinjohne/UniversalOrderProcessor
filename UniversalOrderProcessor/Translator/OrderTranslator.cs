namespace Translator
{
    public class OrderTranslator
    {
        private readonly IPendingFiles pendingFiles;
        private readonly ILogger logger;

        public OrderTranslator(IPendingFiles pendingFiles, ILogger logger)
        {
            this.pendingFiles = pendingFiles;
            this.logger = logger;
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
                    file.MarkSuccessfullyTranslated();
                }
                catch (System.Exception ex)
                {
                    logger.LogException(ex, $"Exception occured while trying to translate order {file.Name}");
                    file.MarkFailedOnTransaltion();
                }

            }
        }
    }
}