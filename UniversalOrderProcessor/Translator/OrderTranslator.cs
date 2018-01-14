using System.Collections.Generic;
using System.Linq;

namespace Translator
{
    public class OrderTranslator
    {
        private readonly IRepository repository;
        private readonly IPendingFiles pendingFiles;
        private readonly ILogger logger;

        public OrderTranslator(IPendingFiles pendingFiles, ILogger logger, IRepository repository)
        {
            this.pendingFiles = pendingFiles;
            this.logger = logger;
            this.repository = repository;
        }

        public void Translate()
        {
            var incomingFiles = pendingFiles.GetAll().Take(10);

            var nativeOrders = new List<INativeFormat>();

            foreach (var file in incomingFiles)
            {
                try
                {
                    var nativeOrder = file.Translate();
                    file.MarkSuccessfullyTranslated();
                    nativeOrders.Add(nativeOrder);
                }
                catch (System.Exception ex)
                {
                    logger.LogException(ex, $"Exception occured while trying to translate order {file.Name}");
                    file.MarkFailedOnTransaltion();
                }
            }

            repository.WriteAll(nativeOrders);
        }
    }
}