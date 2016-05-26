using NUnit.Framework;
using FluentAssertions;
using System.Xml;
using System;
using FriendlyLogger.Config.Provider;

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
            IConfigurationProvider configProvider = null;

            Action act = () => LogManager.GetLogger(configProvider);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Should_ReturnNotNull_When_LoadFromValidXml()
        {
            var provider = new XmlConfigurationprovider();

            var logger = LogManager.GetLogger(provider);

            logger.Should().NotBeNull();
        }

        [TearDown]
        public void TearDown()
        { }

    }

    class XmlConfigurationprovider : IConfigurationProvider
    {

        public XmlDocument LoadConfiguration()
        {
            XmlDocument friendlyLoggerDoc = new XmlDocument();
            friendlyLoggerDoc
                .LoadXml(@"<friendlyLogger>
                            <loggers>
                                <logger name=""FirstLogger"" type=""FriendlyLogger.Logger.FileLogger, FriendlyLogger"">
                                    <levels>
                                        <add value=""ALL""></add>
                                    </levels>
                                    <params>
                                        <add key=""MyKey"" value=""MyValue"" />
                                    </params>
                                </logger>
                            </loggers>
                        </friendlyLogger>");

            return friendlyLoggerDoc;
        }

    }
}
