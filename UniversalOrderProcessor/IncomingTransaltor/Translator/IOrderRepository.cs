using System.Collections.Generic;

namespace Translator
{
    /// <summary>
    /// Order repository to perform database operations
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Writes all native orders to the DB
        /// </summary>
        /// <param name="nativeOrders">The native orders.</param>
        void WriteAll(IEnumerable<INativeFormat> nativeOrders);
    }
}