using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.ForeignOrderFormats;
using Xunit;

namespace Translator.Tests.ForeignOrderFormats
{
    public class AcknowledgmentTests
    {
        private class AcknowledgmentBuilder
        {
            private readonly IApplicationSettings applicationSettings;
            private readonly string fileName;
            private readonly ILogger logger;
            private readonly IFile file;
            public readonly INativeFormat nativeFormat;

            public AcknowledgmentBuilder()
            {
                applicationSettings = Mock.Of<IApplicationSettings>();
                fileName = "TestFile";
                logger = Mock.Of<ILogger>();
                file = Mock.Of<IFile>();
                nativeFormat = Mock.Of<INativeFormat>();
            }

            public Acknowledgment Build()
            {
                return new Acknowledgment(applicationSettings, fileName, logger, file, nativeFormat);
            }

            public AcknowledgmentBuilder WithFileContent(string fileContent)
            {
                Mock.Get(file).Setup(x => x.Read(It.IsAny<string>())).Returns(fileContent);
                return this;
            }
        }

        [Fact]
        public void Translate_FormatsItsContents()
        {
            var fileContent = LoremIpsum;
            var acknowledgmentBuilder = new AcknowledgmentBuilder();
            var acknowledgment = acknowledgmentBuilder.WithFileContent(fileContent).Build();
            var result = acknowledgment.Translate();
            var formattedContent = new String(LoremIpsum.Take(100).ToArray());
            Mock.Get(acknowledgmentBuilder.nativeFormat).Verify(x => x.PrintFrom(formattedContent), Times.Once);
        }

        private string LoremIpsum => $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ut blandit ante, in efficitur sapien. Maecenas ut nunc ut nisl volutpat placerat nec vitae ante. Phasellus posuere egestas lacus in rutrum. Nunc malesuada ac augue sed posuere. Aenean eu eros eget nibh efficitur vestibulum fermentum ut lectus. Praesent pulvinar massa nec felis posuere lobortis. Mauris iaculis nibh sit amet erat condimentum varius. Integer vitae pellentesque risus. Aliquam auctor odio vitae lacinia aliquam.";
    }
}
