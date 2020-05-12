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
    }
}
