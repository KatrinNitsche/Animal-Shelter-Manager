using ASM.BL.Interfaces;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASM.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private ISettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var settingsData = _settingsService.GetSettings();
            SettingsModel model = GetModel(settingsData);
            return View(model);
        }

        public IActionResult Save(SettingsModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MessageType = "danger";
                model.Message = "Some Fields are not valid, please check the individual inputs fields.";
                return View("Index", model);
            }

            var result = _settingsService.Update(GetSettings(model));

            if (result == null)
            {
                model.MessageType = "danger";
                model.Message = "Error while saving the information. Try again and contact support if the problem persists.";
                return View("Index", model);
            }

            model.MessageType = "success";
            model.Message = "Your changes were saved";
            return View("Index", model);
        }
   
        private Data.Settings GetSettings(SettingsModel model)
        {
            return new Data.Settings()
            {
                Title = model.Title,
                Address = new Data.Address()
                {
                    Line1 = model.Line1,
                    Line2 = model.Line2,
                    City = model.City,
                    Country = model.Country,
                    PostCode = model.PostCode
                },
                ContactDetails = new Data.ContactDetails()
                {
                    Email = model.Email,
                    Phone = model.Phone,
                    Mobile = model.Mobile
                }
            };
        }

        private SettingsModel GetModel(Data.Settings settingsData)
        {
            return new SettingsModel()
            {
                Title = settingsData.Title,
                Line1 = settingsData.Address.Line1,
                Line2 = settingsData.Address.Line2,
                City = settingsData.Address.City,
                PostCode = settingsData.Address.PostCode,
                Country = settingsData.Address.Country,
                Email = settingsData.ContactDetails.Email,
                Mobile = settingsData.ContactDetails.Mobile,
                Phone = settingsData.ContactDetails.Phone
            };
        }
    }
}
