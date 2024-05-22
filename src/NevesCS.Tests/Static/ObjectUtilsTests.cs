using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;
using NevesCS.Tests.Mocks;

namespace NevesCS.Tests.Static
{
    public class ObjectUtilsTests
    {
        [Fact]
        public void Set_Should_Set()
        {
            const string str = "whatever";

            MockClass mockClass = new();
            mockClass.SetIfNotNull(m => m.UselessString = str);
            mockClass.UselessString.Should().Be(str);
        }

        [Fact]
        public void SetIfNotNull_Should_NotSet_IfNull()
        {
            const string str = "whatever";

            MockClass? mockClass = new();
            mockClass.SetIfNotNull(m => m.UselessString = str);
            mockClass.UselessString.Should().Be(str);

            MockClass? nullClass = null;
            nullClass.SetIfNotNull(m => m.UselessString = str);
            nullClass.Should().Be(null);
            nullClass!?.UselessString.Should().Be(null);
        }

        [Fact]
        public void ThrowIfNull_Should_Throw_IfNullClass()
        {
            MockClass mockClass = null!;

            MockClass action1() => mockClass.ThrowIfNull();
            MockClass action2() => ObjectUtils.ThrowIfNull(mockClass);

            Array.ForEach(new[] { action1, action2 }, action => action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(MockClass)));
        }

        [Fact]
        public void ThrowIfNull_Should_NotThrow_IfNotNullClass()
        {
            MockClass mockClass = new();

            MockClass action1() => mockClass.ThrowIfNull();
            MockClass action2() => ObjectUtils.ThrowIfNull(mockClass);

            Array.ForEach(new[] { action1, action2 }, action => action.Should().NotThrow());
        }

        [Fact]
        public void Into_Should_TransferObjects()
        {
            const string fakeName = "This is a name I need";
            MockClass mockClass = new() { UselessString = fakeName };

            ObjectUtils.Into(mockClass, mock => new DataGame() { Name = mock.UselessString }).Name.Should().Be(fakeName);
            mockClass.Into(mock => new DataGame() { Name = mock.UselessString }).Name.Should().Be(fakeName);
        }

        [Fact]
        public void Enumerate_Should_EnumerateAllParams()
        {
            var result = ObjectUtils.Enumerate(new DataGame() { AppId = 1 }, new DataGame() { AppId = 2 }, new DataGame() { AppId = 3 }).ToArray();

            result[0].AppId.Should().Be(1);
            result[1].AppId.Should().Be(2);
            result[2].AppId.Should().Be(3);
        }

        [Fact]
        public void Enumerate_Should_EnumerateXTimes()
        {
            var subject = new DataGame() { AppId = 123 };

            subject.Enumerate(0).ToArray().Length.Should().Be(0);
            subject.Enumerate(1).ToArray().Length.Should().Be(1);
            subject.Enumerate(3).ToArray().Length.Should().Be(3);
            subject.Enumerate(10).ToArray().Length.Should().Be(10);
        }

        [Fact]
        public void EnumerateClones_Should_EnumerateClonesXTimes()
        {
            DataGame subject = new() { AppId = 123 };

            subject.EnumerateClones<DataGame>(0).ToArray().Length.Should().Be(0);
            subject.EnumerateClones<DataGame>(1).ToArray().Length.Should().Be(1);
            subject.EnumerateClones<DataGame>(3).ToArray().Length.Should().Be(3);
            subject.EnumerateClones<DataGame>(10).ToArray().Length.Should().Be(10);
        }

        [Fact]
        public void ToArray_Should_CreateNewArrayWithTheObject()
        {
            DataGame subject = new() { AppId = 123 };

            var array1 = subject.ToArray();
            var array2 = ObjectUtils.ToArray(subject);

            array1[0].Should().BeSameAs(subject);
            array1.Should().HaveCount(1);
            array2[0].Should().BeSameAs(subject);
            array2.Should().HaveCount(1);
        }

        [Fact]
        public void HasProperty_Should_Pass()
        {
            var mockClass = (object)new DataGame();

            mockClass.HasProperty(nameof(DataGame.Developer)).Should().Be(true);
            ObjectUtils.HasProperty(mockClass, nameof(DataGame.Developer)).Should().Be(true);

            mockClass.HasProperty(nameof(Array.Length)).Should().Be(false);
            ObjectUtils.HasProperty(mockClass, nameof(Array.Length)).Should().Be(false);
        }

        [Fact]
        public void SetPropertyDynamically_Should_SetValue()
        {
            const string dev = "J. P. M. Neves";
            const int appId = 123456789;

            var mockClass = (object)new DataGame();

            mockClass.SetPropertyDynamically(nameof(DataGame.Developer), dev);
            mockClass.SetPropertyDynamically(nameof(DataGame.AppId), appId);

            var castResult = (DataGame)mockClass;
            castResult.Developer.Should().Be(dev);
            castResult.AppId.Should().Be(appId);
        }

        [Fact]
        public void SetPropertyDynamically_Should_SetsTheValueOfASubProperty()
        {
            var mockClass = (object)new DataGame();

            mockClass.SetPropertyDynamically(nameof(DataGame.Platforms), new DataPlatforms());
            mockClass.SetPropertyDynamically($"{nameof(DataGame.Platforms)}.{nameof(DataPlatforms.Linux)}", true);

            var castResult = (DataGame)mockClass;
            castResult.Platforms.Linux.Should().Be(true);
            castResult.Platforms.Windows.Should().Be(false);
            castResult.Platforms.Mac.Should().Be(false);
        }

        private IEnumerable<string> GetMockEnumerable() => new[] { 1, 2, 3 }.Select(x => x.ToString());

        [Fact]
        public void CallMethodOfPropertyDynamically_Should_CallAddRange()
        {
            var values = GetMockEnumerable();

            var mockClass = (object)new MockClass() { UselessList = new List<string>() };

            CallAddRangeOnTarget(mockClass, values);

            var castResult = (MockClass)mockClass;
            castResult.UselessList.Should().BeEquivalentTo(values);
        }

        [Fact]
        public void CallMethodOfPropertyDynamically_Should_ThrowOnInvalidProperty()
        {
            var values = Enumerable.Empty<string>();

            var mockClass = (object)new MockClass();

            var action = () => mockClass.CallMethodOfPropertyDynamically(
                "ThisPropertyDoesNotExist",
                nameof(MockClass.UselessList.AddRange),
                values);

            action.Should().Throw<MissingFieldException>().WithMessage("ThisPropertyDoesNotExist");
        }

        [Fact]
        public void CallMethodOfPropertyDynamically_Should_ThrowOnInvalidMethod()
        {
            var values = Enumerable.Empty<string>();

            var mockClass = (object)new MockClass();

            var action = () => mockClass.CallMethodOfPropertyDynamically(
                nameof(MockClass.UselessList),
                "ThisMethodDoesNotExist",
                values);

            action.Should().Throw<MissingMethodException>().WithMessage("ThisMethodDoesNotExist");
        }

        [Fact]
        public void CallMethodOfPropertyDynamically_Should_ThrowOnNullProperty()
        {
            var values = Enumerable.Empty<string>();

            var mockClass = (object)new MockClass() { UselessList = null! };

            var action = () => CallAddRangeOnTarget(mockClass, values);

            action.Should().Throw<NullReferenceException>().WithMessage(nameof(MockClass.UselessList));
        }

        private void CallAddRangeOnTarget(object targetClass, object values)
        {
            targetClass.CallMethodOfPropertyDynamically(
                nameof(MockClass.UselessList),
                nameof(MockClass.UselessList.AddRange),
                values);
        }
    }
}
