﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    /// <summary>
    /// Translate order and write translated orders to database
    /// </summary>
    /// <seealso cref="Translator.IOrderTranslator" />
    public class OrderTranslator : IOrderTranslator
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
            parallelFileProcessLimit = applicationSettings.PendingFilesProcessLimit;
        }

        /// <summary>
        /// Translates this instance.
        /// </summary>
        public void Translate()
        {
            var incomingFiles = pendingFiles.GetAll().Take(parallelFileProcessLimit);

            if (incomingFiles.Count() == 0)
            {
                logger.Info("No pending files to process");
                return;
            }

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
                    logger.Fatal(ex, $"Exception occurred while trying to translate order {file.Name}");
                    file.MarkFailedOnTranslation();
                }
            });

            repository.WriteAll(nativeOrders);
        }
    }
}