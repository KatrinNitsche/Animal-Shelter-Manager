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

        public SettingsService(ISettingsRepository repository)
        {
            _repository = repository;
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
                _repository.Add(new Settings()
                {
                    Id = id,
                    Title = "Your Animal Shelter",
                    Address = address,
                    ContactDetails = contact
                });

                id = idNew;
            }
            else
            {
                id = _repository.GetAll().First().Id;
            }
            

            return _repository.GetById(id);           
        }

        public Settings Update(Settings settings)
        {
            return _repository.Update(settings);
        }
    }
}
