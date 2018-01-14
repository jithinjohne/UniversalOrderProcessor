using Moq;
using Xunit;

namespace Translator.Tests
{
    public class OrderTranslatorTests
    {
        private readonly OrderTranslator orderTranslator;
        private readonly IPendingFiles pendingFiles;

        public OrderTranslatorTests()
        {
            pendingFiles = Mock.Of<IPendingFiles>();
            orderTranslator = new OrderTranslator(pendingFiles);
        }

        [Fact]
        public void Translate_GetsCurrentPendingOrders()
        {
            orderTranslator.Translate();
            Mock.Get(pendingFiles).Verify(x => x.GetFiles(), Times.Once);
        }
    }
}