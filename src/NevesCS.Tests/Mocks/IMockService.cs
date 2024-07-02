using Moq;

namespace NevesCS.Tests.Mocks
{
    public interface IMockService
    {
        public string UselessMethod(string whatever);
    }

    public static class IMockServiceExtensions
    {
        public static void SetupUselessMethod(this Mock<IMockService> mock)
        {
            mock.Setup(m => m.UselessMethod(It.IsAny<string>())).Returns<string>(whatever => whatever);
        }
    }
}
