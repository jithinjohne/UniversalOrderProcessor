using NLog;
using System;
using System.Collections.Generic;

namespace OrderSource
{
    /// <summary>
    /// This class polls through all order sources and tells each source to move orders
    /// </summary>
    public class AllOrderSources : IReceivable
    {
        private readonly IList<IMovable> orderSources;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AllOrderSources()
        {
            orderSources = new List<IMovable>
            {
                new Email(),
                new FTP(),
                new MQSource()
            };
        }

        /// <summary>
        /// Receive orders
        /// </summary>
        public void Receive()
        {
            logger.Debug("Started Proces");

            for (int i = 0; i < 2; i++)
            {
                logger.Debug($"Going through iteration {i}");

                PollOrderSources();
            }
        }

        private void PollOrderSources()
        {
            foreach (var orderSource in orderSources)
            {
                try
                {
                    orderSource.Move();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, $"Error occured on source {orderSource}");
                }
            }
        }
    }
}