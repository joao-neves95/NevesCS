using FluentAssertions;

using Moq;

using NevesCS.Static.Extensions;
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

        [Fact]
        public void Upsert_Should_Add_If_ValueDoesNotExist()
        {
            var dict = new Dictionary<string, object>();

            DictionaryUtils.Upsert(dict, "A", "a");
            dict.Upsert("B", "b");

            var allValues = dict.Values.ToArray();
            allValues.Should().BeEquivalentTo(new[] { "a", "b" });
        }

        [Fact]
        public void Upsert_Should_Update_If_ValueExists()
        {
            var dict = new Dictionary<string, object>()
            {
                { "A", "b" },
                { "B", "a" },
            };

            DictionaryUtils.Upsert(dict, "A", "a");
            dict.Upsert("B", "b");

            var allValues = dict.Values.ToArray();
            allValues.Should().BeEquivalentTo(new[] { "a", "b" });
        }

        private void VerifyGetOrCreateResult(Dictionary<string, object> targetDict, string key, string value, bool wasCalled)
        {
            var targetDict2 = targetDict.CloneIntoNew();

            DictionaryUtils.GetOrCreate(targetDict, key, factoryMock.Object).Should().Be(value);
            targetDict2.GetOrCreate(key, factoryMock.Object).Should().Be(value);

            // 2 times because it should be called by both dictionaries 1 time.
            factoryMock.Verify(mock => mock(), wasCalled ? Times.Exactly(2) : Times.Never());
        }
    }
}
