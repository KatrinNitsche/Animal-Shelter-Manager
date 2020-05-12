using ASM.Web.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ASM.Tests
{
    public class SettingsControllerTests
    {
        private ILogger<SettingsController> logger;

        public SettingsControllerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            logger = factory.CreateLogger<SettingsController>();            
        }

        [Fact]
        public void CreateSettingsController()
        {


            SettingsController sut = new SettingsController(logger);
            Assert.NotNull(sut);
        }

        [Fact]
        public void RequestIndexFromController()
        {
            SettingsController sut = new SettingsController(logger);
            var response = sut.Index();

            Assert.NotNull(response);
        }
    }
}
