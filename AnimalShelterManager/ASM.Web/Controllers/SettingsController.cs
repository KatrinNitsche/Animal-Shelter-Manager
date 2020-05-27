using ASM.BL;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASM.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private SettingsService settingsService;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
            settingsService = new SettingsService();
        }

        public IActionResult Index()
        {
            var settingsData = settingsService.GetSettings();
            SettingsModel model = new SettingsModel()
            {
                Title = settingsData.Title,
                Line1 = settingsData.Address.Line1,
                Line2 = settingsData.Address.Line2,
                City = settingsData.Address.City,
                PostCode = settingsData.Address.PostCode,
                Country = settingsData.Address.Country
            };

            return View(model);
        }
        
    }
}
