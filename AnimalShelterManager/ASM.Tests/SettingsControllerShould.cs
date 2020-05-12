using ASM.Web.Controllers;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ASM.Tests
{
    public class SettingsControllerShould 
    {
        private ILogger<SettingsController> logger;

        public SettingsControllerShould()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            logger = factory.CreateLogger<SettingsController>();            
        }

        [Fact]
        public void BeCreated()
        {
            SettingsController sut = new SettingsController(logger);
            Assert.NotNull(sut);
        }

        [Fact]
        public void ReturnIndexPage()
        {
            SettingsController sut = new SettingsController(logger);
            var response = sut.Index();

            Assert.NotNull(response);
        }

        [Fact]
        public void ReturnIndexPageWithViewModel()
        {
            SettingsController sut = new SettingsController(logger);
            IActionResult response = sut.Index();

            Assert.NotNull(response);

            var viewResult = Assert.IsType<ViewResult>(response);
            SettingsModel model = viewResult.ViewData.Model as SettingsModel;

            Assert.Equal("Your Animal Shelter", model.Title);
        }
    }
}
