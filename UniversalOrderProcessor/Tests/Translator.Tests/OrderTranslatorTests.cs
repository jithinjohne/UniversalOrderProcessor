using Moq;
using System;
using System.Collections.Generic;
using Translator.ForeignOrderFormats;
using Xunit;

namespace Translator.Tests
{
    public class OrderTranslatorTests
    {
        private class OrderTranslatorBuilder
        {
            public readonly IPendingFiles pendingFiles;
            public IList<IForeignFormat> incomingFiles;
            public readonly ILogger logger;
            public readonly IOrderRepository repository;
            private readonly IApplicationSettings applicationSettings;

            public OrderTranslatorBuilder()
            {
                pendingFiles = Mock.Of<IPendingFiles>();
                logger = Mock.Of<ILogger>();
                repository = Mock.Of<IOrderRepository>();
                applicationSettings = Mock.Of<IApplicationSettings>();
            }

            public OrderTranslatorBuilder WithPendingFilesSetup()
            {
                incomingFiles = new List<IForeignFormat>() {
                    Mock.Of<IForeignFormat>(),
                    Mock.Of<IForeignFormat>(),
                    Mock.Of<IForeignFormat>()
                };
                Mock.Get(pendingFiles).Setup(x => x.GetAll()).Returns(incomingFiles);
                return this;
            }

            public OrderTranslatorBuilder WithDefaultApplicationSettings()
            {
                Mock.Get(applicationSettings).Setup(x => x.ParallelFileProcessLimit).Returns(10);
                return this;
            }

            public OrderTranslator Build()
            {
                return new OrderTranslator(pendingFiles, logger, repository, applicationSettings);
            }

            public OrderTranslatorBuilder WithSecondFileFailingOnTranslation()
            {
                var file1 = Mock.Of<IForeignFormat>();
                var file2 = Mock.Of<IForeignFormat>();
                Mock.Get(file2).Setup(x => x.Translate()).Throws<Exception>();
                var file3 = Mock.Of<IForeignFormat>();
                incomingFiles = new List<IForeignFormat>() {
                    file1, file2, file3
                };
                Mock.Get(pendingFiles).Setup(x => x.GetAll()).Returns(incomingFiles);
                return this;
            }
        }

        [Fact]
        public void Translate_TranslatesPendingOrders()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithPendingFilesSetup().WithDefaultApplicationSettings().Build();
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
            var translator = builder.WithPendingFilesSetup().WithDefaultApplicationSettings().Build();
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
            var translator = builder.WithSecondFileFailingOnTranslation().WithDefaultApplicationSettings().Build();
            translator.Translate();

            Mock.Get(builder.incomingFiles[0]).Verify(x => x.MarkSuccessfullyTranslated(), Times.Once);
            Mock.Get(builder.incomingFiles[1]).Verify(x => x.MarkFailedOnTransaltion(), Times.Once);
            Mock.Get(builder.incomingFiles[2]).Verify(x => x.MarkSuccessfullyTranslated(), Times.Once);
        }

        [Fact]
        public void Translate_LogsWhenThereIsAFailure()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithSecondFileFailingOnTranslation().WithDefaultApplicationSettings().Build();
            translator.Translate();
            Mock.Get(builder.logger).Verify(x => x.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_WritesAllTranslatedFilesToRepository()
        {
            var builder = new OrderTranslatorBuilder();
            var translator = builder.WithPendingFilesSetup().Build();
            translator.Translate();
            Mock.Get(builder.repository).Verify(x => x.WriteAll(It.IsAny<IEnumerable<INativeFormat>>()), Times.Once);
        }
    }
}