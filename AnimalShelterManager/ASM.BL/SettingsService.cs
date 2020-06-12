using ASM.BL.Interfaces;
using ASM.DAL.Interfaces;
using ASM.Data;
using System;
using System.Linq;

namespace ASM.BL
{
    public class SettingsService : ISettingsService
    {
        private ISettingsRepository _repository;
        private IAddressRepository _addressRepository;
        private IContactDetailsRepository _contactDetailsRepository;

        public SettingsService(ISettingsRepository repository, IAddressRepository addressRepository, IContactDetailsRepository contactDetailsRepository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
            _contactDetailsRepository = contactDetailsRepository;
        }

        public Settings Add(Settings settings)
        {
            settings.ContactDetails = _contactDetailsRepository.Add(settings.ContactDetails);
            settings.Address = _addressRepository.Add(settings.Address);
            
            return _repository.Add(settings);
        }

        public Settings GetSettings()
        {
            // ToDo: get settings id for the settings of the current user
            Guid id = new Guid();

            if (_repository.GetAll().Count() == 0)
            {
                var address = new Address()
                {
                    Id = Guid.NewGuid(),
                    Line1 = "Address Line 1",
                    Line2 = "Address Line 2",
                    PostCode = "A12 3BC",
                    City = "London",
                    Country = "United Kingdom"
                };

                var contact = new ContactDetails()
                {
                    Id = Guid.NewGuid(),
                    Email = "Test@test.com",
                    Phone = "01234 56789",
                    Mobile = "09876 54321"
                };

                var idNew = Guid.NewGuid();

                var newSettings = new Settings()
                {
                    Id = id,
                    Title = "Your Animal Shelter",
                    Address = address,
                    ContactDetails = contact
                };

                Add(newSettings);
                return newSettings;
            }
            else
            {
                id = _repository.GetAll().First().Id;
            }
            
            var settingsData = _repository.GetById(id);
            settingsData.Address = _addressRepository.GetById(settingsData.AddressId);
            settingsData.ContactDetails = _contactDetailsRepository.GetById(settingsData.ContactDetailsId);
           
            return settingsData;
        }

        public Settings Update(Settings settings)
        {
            settings.ContactDetails = _contactDetailsRepository.Update(settings.ContactDetails);
            settings.Address = _addressRepository.Update(settings.Address);

            return _repository.Update(settings);
        }
    }
}