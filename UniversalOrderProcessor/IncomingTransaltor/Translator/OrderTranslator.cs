using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    /// <summary>
    /// Translate order and write translated orders to database
    /// </summary>
    /// <seealso cref="Translator.IOrderTranslaor" />
    public class OrderTranslator : IOrderTranslaor
    {
        private readonly int parallelFileProcessLimit;
        private readonly IOrderRepository repository;
        private readonly IPendingFiles pendingFiles;
        private readonly ILogger logger;

        public OrderTranslator(IPendingFiles pendingFiles, ILogger logger, IOrderRepository repository, IApplicationSettings applicationSettings)
        {
            this.pendingFiles = pendingFiles;
            this.logger = logger;
            this.repository = repository;
            this.parallelFileProcessLimit = applicationSettings.PendingFilesProcessLimit;
        }

        /// <summary>
        /// Translates this instance.
        /// </summary>
        public void Translate()
        {
            var incomingFiles = pendingFiles.GetAll().Take(parallelFileProcessLimit);

            var nativeOrders = new List<INativeFormat>();

            Parallel.ForEach(incomingFiles, file =>
            {
                try
                {
                    var nativeOrder = file.Translate();
                    file.MarkSuccessfullyTranslated();
                    nativeOrders.Add(nativeOrder);
                }
                catch (Exception ex)
                {
                    logger.LogFatal(ex, $"Exception occurred while trying to translate order {file.Name}");
                    file.MarkFailedOnTransaltion();
                }
            });

            repository.WriteAll(nativeOrders);
        }
    }
}