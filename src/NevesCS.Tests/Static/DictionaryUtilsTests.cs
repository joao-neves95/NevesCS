using FluentAssertions;

using Moq;

using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static
{
    public class DictionaryUtilsTests
    {
        private const string fakeString = "a test string";

        private readonly Mock<Func<string>> factoryMock = new();

        public DictionaryUtilsTests()
        {
            factoryMock.Setup(mock => mock()).Returns(() => fakeString);
        }

        [Fact]
        public void GetOrCreate_Should_Create_If_ValueDoesNotExist()
        {
            var dict = new Dictionary<string, object>();

            VerifyGetOrCreateResult(dict, "1", fakeString, true);
        }

        [Fact]
        public void GetOrCreate_Should_GetExistingValue_If_ValueExists()
        {
            var dict = new Dictionary<string, object>()
            {
                { "1", fakeString },
            };

            VerifyGetOrCreateResult(dict, "1", fakeString, false);
        }

        private void VerifyGetOrCreateResult(Dictionary<string, object> targetDict, string key, string value, bool wasCalled)
        {
            var targetDict2 = targetDict.CloneIntoNew();

            DictionaryUtils.GetOrCreate(targetDict, key, factoryMock.Object).Should().Be(value);
            targetDict2.GetOrCreate(key, factoryMock.Object).Should().Be(value);

            factoryMock.Verify(mock => mock(), wasCalled ? Times.Exactly(2) : Times.Never());
        }
    }
}
