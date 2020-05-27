using ASM.Data;

namespace ASM.BL
{
    public class SettingsService
    {
        private Settings settings;

        public SettingsService()
        {
            SetDummyData();
        }

        private void SetDummyData()
        {
            var address = new Address()
            {
                Line1 = "Address Line 1",
                Line2 = "Address Line 2",
                PostCode = "A12 3BC",
                City = "London",
                Country = "United Kingdom"
            };

            settings = new Settings() { Title = "Your Animal Shelter", Address = address };
        }

        public Settings GetSettings()
        {
            return settings;
           
        }

        public Settings Update(Settings settings)
        {
            settings.Title = settings.Title;
            settings.Address = settings.Address;

            return settings;
        }
    }
}
