using Moq;

using NevesCS.Abstractions.Traits;
using NevesCS.Tests.Mocks;

namespace NevesCS.Tests.Abstractions.Traits
{
    public class IAsyncInitializableTests
    {
        private abstract class ParentAsyncInitializable : IAsyncInitializable
        {
            private readonly IMockService CallCounter;

            protected ParentAsyncInitializable(IMockService callCounter)
            {
                CallCounter = callCounter;
            }

            public Task InitializeAsync()
            {
                CallCounter.UselessMethod("Parent");
                return Task.CompletedTask;
            }
        }

        private class ChildAsyncInitializable : ParentAsyncInitializable
        {
            private readonly IMockService CallCounter;

            public ChildAsyncInitializable(IMockService callCounter) : base(callCounter)
            {
                CallCounter = callCounter;
            }

            public new Task InitializeAsync()
            {
                CallCounter.UselessMethod("Child");
                return Task.CompletedTask;
            }
        }

        private readonly Mock<IMockService> CallCounter = new();

        public IAsyncInitializableTests()
        {
            CallCounter.SetupUselessMethod();
        }

        [Fact]
        public async Task AsyncInitializable_OnlyChildIsCalled()
        {
            var sut = new ChildAsyncInitializable(CallCounter.Object);

            await sut.InitializeAsync();

            CallCounter.Verify(mock => mock.UselessMethod("Child"), Times.Once);
            CallCounter.Verify(mock => mock.UselessMethod("Parent"), Times.Never);
        }
    }
}
