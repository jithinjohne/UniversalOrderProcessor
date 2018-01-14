using System.Collections.Generic;

namespace Translator
{
    public interface IRepository
    {
        void WriteAll(IEnumerable<INativeFormat> nativeOrders);
    }
}