using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Tests.Mocks;

namespace NevesCS.Tests.Static.Extensions
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ThrowIfNull_Should_Throw_IfNullClass()
        {
            MockClass mockClass = null!;

            var action = () => mockClass.ThrowIfNull();

            action.Should()
                .Throw<ArgumentNullException>()
                .WithParameterName(nameof(MockClass));
        }

        [Fact]
        public void ThrowIfNull_Should_NotThrow_IfNotNullClass()
        {
            MockClass mockClass = new();

            var action = () => mockClass.ThrowIfNull();

            action.Should().NotThrow();
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
