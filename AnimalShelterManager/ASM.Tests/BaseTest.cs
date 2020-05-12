using Xunit.Abstractions;

namespace ASM.Tests
{
    public class BaseTest
    {
        public readonly ITestOutputHelper _output;

        public BaseTest(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}
