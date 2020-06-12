using ASM.BL;
using ASM.BL.Interfaces;
using ASM.DAL;
using ASM.DAL.Interfaces;
using ASM.DAL.Repositories;
using ASM.Web.Controllers;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ASM.Tests
{
    public class SettingsControllerShould 
    {
        private ILogger<SettingsController> logger;
        private DbContextOptions<DataContext> options;

        public SettingsControllerShould()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            logger = factory.CreateLogger<SettingsController>();

            options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase("InMemoryData")
               .Options;
        }

        [Fact]
        public void BeCreated()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService settingsService = new SettingsService(repository, addressRepository, contactDetailsRepository);
                SettingsController sut = new SettingsController(logger, settingsService);
                Assert.NotNull(sut);
            }
        }

        [Fact]
        public void ReturnIndexPage()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService settingsService = new SettingsService(repository, addressRepository, contactDetailsRepository);
                SettingsController sut = new SettingsController(logger, settingsService);
                
                var response = sut.Index();

                Assert.NotNull(response);
            }           
        }

        [Fact]
        public void ReturnIndexPageWithViewModel()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService settingsService = new SettingsService(repository, addressRepository, contactDetailsRepository);
                SettingsController sut = new SettingsController(logger, settingsService);
                IActionResult response = sut.Index();

                Assert.NotNull(response);

                var viewResult = Assert.IsType<ViewResult>(response);
                SettingsModel model = viewResult.ViewData.Model as SettingsModel;

                Assert.Equal("Your Animal Shelter", model.Title);
            }
        }
    }
}
