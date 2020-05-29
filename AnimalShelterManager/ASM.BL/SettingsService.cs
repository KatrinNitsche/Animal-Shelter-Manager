using ASM.BL.Interfaces;
using ASM.Data;

namespace ASM.BL
{
    // ToDo: change this service to use a repository for permanent storage

    public class SettingsService : ISettingsService
    {
        private Settings _settings;

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

            var contact = new ContactDetails()
            {
                Email = "Test@test.com",
                Phone = "01234 56789",
                Mobile = "09876 54321"
            };

            _settings = new Settings() { Title = "Your Animal Shelter", Address = address, ContactDetails = contact };
        }

        public Settings GetSettings()
        {
            return _settings;
           
        }

        public Settings Update(Settings settings)
        {
            _settings.Title = settings.Title;
            _settings.Address = settings.Address;
            _settings.ContactDetails = settings.ContactDetails;

            return _settings;
        }
    }
}
