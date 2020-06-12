using ASM.BL;
using ASM.BL.Interfaces;
using ASM.DAL;
using ASM.DAL.Interfaces;
using ASM.DAL.Repositories;
using ASM.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ASM.Tests
{
    public class SettingsServicesShould
    {
        private DbContextOptions<DataContext> options;

        public SettingsServicesShould()
        {
            options = new DbContextOptionsBuilder<DataContext>()
              .UseInMemoryDatabase("InMemoryData")
              .Options;
        }

        [Fact]
        public void ReturnSettings()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);

                var settings = sut.GetSettings();

                Assert.NotNull(settings);
            }
        }

        [Fact]
        public void ReturnSettingsAsObject()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);
             
                Settings settings = sut.GetSettings();

                Assert.True(settings is Settings);
            }
        }

        [Fact]
        public void ReturnSettingsWithData()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);

                Settings settings = sut.GetSettings();

                Assert.Equal("Your Animal Shelter", settings.Title);
            }
        }

        [Fact]
        public void UpdateSettings()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);

                Settings settings = sut.GetSettings();
                settings.Title = "Changed Shelter Name";

                var newSettings = sut.Update(settings);

                Assert.Equal("Changed Shelter Name", newSettings.Title);
            }
        }

        [Fact]
        public void ContainAnAddress()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);

                var settings = sut.GetSettings();
                var address = settings.Address;

                Assert.NotNull(address);
            }
        }

        [Fact]
        public void ContainAnAddressWithDetails()
        {
            using (var context = new DataContext(options))
            {
                ISettingsRepository repository = new SettingsRepository(context);
                IAddressRepository addressRepository = new AddressRepository(context);
                IContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository(context);
                ISettingsService sut = new SettingsService(repository, addressRepository, contactDetailsRepository);

                var settings = sut.GetSettings();
                var address = settings.Address;

                Assert.Equal("Address Line 1", address.Line1);
                Assert.Equal("Address Line 2", address.Line2);
                Assert.Equal("A12 3BC", address.PostCode);
                Assert.Equal("London", address.City);
                Assert.Equal("United Kingdom", address.Country);
            }
        }
    }
}