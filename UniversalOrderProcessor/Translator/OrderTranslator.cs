﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    public class OrderTranslator
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
            this.parallelFileProcessLimit = applicationSettings.ParallelFileProcessLimit;

        }

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
                    logger.LogException(ex, $"Exception occured while trying to translate order {file.Name}");
                    file.MarkFailedOnTransaltion();
                }
            });

            repository.WriteAll(nativeOrders);
        }
    }
}