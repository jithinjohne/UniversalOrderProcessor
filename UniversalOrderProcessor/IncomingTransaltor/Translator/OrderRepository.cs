using System.Collections.Generic;
using System.Linq;

namespace Translator
{
    /// <summary>
    /// Order repository
    /// </summary>
    /// <seealso cref="Translator.IOrderRepository" />
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger logger;

        public OrderRepository(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Writes all native orders to the DB
        /// </summary>
        /// <param name="nativeOrders">The native orders.</param>
        public void WriteAll(IEnumerable<INativeFormat> nativeOrders)
        {
            //To-do : Add database operations here
            logger.Debug(string.Format($"Successfully wrote {nativeOrders.Count()} to the db"));
        }
    }
}