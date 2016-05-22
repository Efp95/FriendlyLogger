using FluentAssertions;
using FriendlyLogger.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace FriendlyLogger.Tests.Core
{
    [TestFixture]
    public class LevelMappingTest
    {

        [SetUp]
        public void SetUp()
        { }


        [Test]
        public void Should_ReturnOneItem_When_CollectionIsNull()
        {
            IEnumerable<Level> levels = null;

            levels = LevelMapping.Execute(null);

            levels.Should().NotBeNullOrEmpty().And.HaveCount(1);
        }

        [Test]
        public void Should_ReturnDebugLevel_When_CollectionIsNull()
        {
            IEnumerable<Level> levels = null;

            levels = LevelMapping.Execute(null);

            using (var enumerator = levels.GetEnumerator())
            {
                enumerator.MoveNext();
                enumerator.Current.Name.Should().Be("DEBUG");
            }
        }


        [TearDown]
        public void TearDown()
        { }

    }
}
