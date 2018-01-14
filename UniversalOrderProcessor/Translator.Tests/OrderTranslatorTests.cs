using Moq;
using System.Collections.Generic;
using Xunit;

namespace Translator.Tests
{
    public class OrderTranslatorTests
    {
        private class OrderTranslatorBuilder
        {
            public readonly IPendingFiles pendingFiles;
            public readonly IList<IIncomingFile> incomingFiles;

            public OrderTranslatorBuilder()
            {
                pendingFiles = Mock.Of<IPendingFiles>();
                incomingFiles = new List<IIncomingFile>() {
                    Mock.Of<IIncomingFile>(),
                    Mock.Of<IIncomingFile>(),
                    Mock.Of<IIncomingFile>()
                };
            }

            public OrderTranslatorBuilder WithPendingFilesSetup()
            {
                Mock.Get(pendingFiles).Setup(x => x.GetFiles()).Returns(incomingFiles);
                return this;
            }

            public OrderTranslator Build()
            {
                return new OrderTranslator(pendingFiles);
            }
        }

        [Fact]
        public void Translate_TranslatesPendingOrders()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithPendingFilesSetup().Build();
            translator.Translate();
            foreach (var file in builder.incomingFiles)
            {
                Mock.Get(file).Verify(x => x.Translate(), Times.Once);
            }
        }
    }
}