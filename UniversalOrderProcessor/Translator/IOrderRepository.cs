using System.Collections.Generic;

namespace Translator
{
    public interface IOrderRepository
    {
        void WriteAll(IEnumerable<INativeFormat> nativeOrders);
    }
}