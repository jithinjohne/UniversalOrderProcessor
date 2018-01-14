using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Translator.Tests
{
    public class OrderTranslatorTests
    {
        private class OrderTranslatorBuilder
        {
            public readonly IPendingFiles pendingFiles;
            public IList<IIncomingFile> incomingFiles;
            public readonly ILogger logger;

            public OrderTranslatorBuilder()
            {
                pendingFiles = Mock.Of<IPendingFiles>();
                logger = Mock.Of<ILogger>();
            }

            public OrderTranslatorBuilder WithPendingFilesSetup()
            {
                incomingFiles = new List<IIncomingFile>() {
                    Mock.Of<IIncomingFile>(),
                    Mock.Of<IIncomingFile>(),
                    Mock.Of<IIncomingFile>()
                };
                Mock.Get(pendingFiles).Setup(x => x.GetFiles()).Returns(incomingFiles);
                return this;
            }

            public OrderTranslator Build()
            {
                return new OrderTranslator(pendingFiles, logger);
            }

            public OrderTranslatorBuilder WithOneFileFailingOnTranslation()
            {
                var file1 = Mock.Of<IIncomingFile>();
                var file2 = Mock.Of<IIncomingFile>();
                Mock.Get(file2).Setup(x => x.Translate()).Throws<Exception>();
                var file3 = Mock.Of<IIncomingFile>();
                incomingFiles = new List<IIncomingFile>() {
                    file1, file2, file3
                };
                Mock.Get(pendingFiles).Setup(x => x.GetFiles()).Returns(incomingFiles);
                return this;
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

        [Fact]
        public void Translate_TagsSuccessfullyTranslatedFiles()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithPendingFilesSetup().Build();
            translator.Translate();
            foreach (var file in builder.incomingFiles)
            {
                Mock.Get(file).Verify(x => x.MarkSuccessfullyTranslated(), Times.Once);
            }
        }

        [Fact]
        public void Translate_TagsTranslationFailedFiles()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithOneFileFailingOnTranslation().Build();
            translator.Translate();

            Mock.Get(builder.incomingFiles[0]).Verify(x => x.MarkSuccessfullyTranslated(), Times.Once);
            Mock.Get(builder.incomingFiles[1]).Verify(x => x.MarkFailedOnTransaltion(), Times.Once);
            Mock.Get(builder.incomingFiles[2]).Verify(x => x.MarkSuccessfullyTranslated(), Times.Once);
        }

        [Fact]
        public void Translate_LogsWhenThereIsAFailure()
        {
            var builder = new OrderTranslatorBuilder();

            var translator = builder.WithOneFileFailingOnTranslation().Build();
            translator.Translate();
            Mock.Get(builder.logger).Verify(x => x.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }
    }
}