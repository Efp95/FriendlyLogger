using NUnit.Framework;
using FluentAssertions;
using System.Xml;
using System;

namespace FriendlyLogger.Tests
{
    [TestFixture]
    public class LogManagerTest
    {

        [SetUp]
        public void SetUp()
        { }

        [Test]
        public void Should_ThrowException_When_LoadFromNullXml()
        {
            XmlDocument friendlyLoggerDoc = null;

            Action act = () => LogManager.GetLogger(friendlyLoggerDoc);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Should_ReturnNotNull_When_LoadFromValidXml()
        {
            XmlDocument friendlyLoggerDoc = new XmlDocument();
            friendlyLoggerDoc
                .LoadXml(@"<friendlyLogger>
                            <loggers>
                                <logger name=""FirstLogger"" type=""FriendlyLogger.Logger.FileLogger, FriendlyLogger"">
                                    <levels>
                                        <add value=""ALL""></add>
                                    </levels>
                                </logger>
                            </loggers>
                        </friendlyLogger>");

            var logger = LogManager.GetLogger(friendlyLoggerDoc);

            logger.Should().NotBeNull();
        }

        [TearDown]
        public void TearDown()
        { }

    }
}
