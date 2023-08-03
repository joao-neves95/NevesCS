using FluentAssertions;

using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static.Extensions
{
    public class GuidExtensionsTests
    {
        [Fact]
        public void IsNullOrEmpty_HasNoNullReference()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;
            Guid? guid3 = Guid.NewGuid();

            guid1.IsNullOrEmpty().Should().Be(true);
            guid2.IsNullOrEmpty().Should().Be(true);
            guid3.IsNullOrEmpty().Should().Be(false);
        }
    }
}
