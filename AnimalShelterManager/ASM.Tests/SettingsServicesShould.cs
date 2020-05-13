using ASM.BL;
using ASM.Data;
using Xunit;

namespace ASM.Tests
{
    public class SettingsServicesShould
    {
        [Fact]
        public void ReturnSettings()
        {
            SettingsService sut = new SettingsService();

            var settings = sut.GetSettings();

            Assert.NotNull(settings);
        }

        [Fact]
        public void ReturnSettingsAsObject()
        {
            SettingsService sut = new SettingsService();

            Settings settings = sut.GetSettings();

            Assert.True(settings is Settings);
        }

        [Fact]
        public void ReturnSettingsWithData()
        {
            SettingsService sut = new SettingsService();

            Settings settings = sut.GetSettings();

            Assert.Equal("Your Animal Shelter", settings.Title);
        }

        [Fact]
        public void UpdateSettings()
        {
            SettingsService sut = new SettingsService();

            Settings settings = sut.GetSettings();
            settings.Title = "Changed Shelter Name";

            var newSettings = sut.Update(settings);

            Assert.Equal("Changed Shelter Name", newSettings.Title);
        }
   
        [Fact]
        public void ContainAnAddress()
        {
            SettingsService sut = new SettingsService();

            var settings = sut.GetSettings();
            var address = settings.Address;

            Assert.NotNull(address);
        }

        [Fact]
        public void ContainAnAddressWithDetails()
        {
            SettingsService sut = new SettingsService();

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
