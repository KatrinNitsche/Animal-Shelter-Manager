using ASM.BL.Interfaces;
using ASM.Data;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ASM.Web.Controllers
{
    public class AnimalController : Controller
    {
        private ILogger<AnimalController> logger;
        private IAnimalService _animalService;

        public AnimalController(ILogger<AnimalController> logger, IAnimalService animalService)
        {
            this.logger = logger;
            this._animalService = animalService;
        }

        public IActionResult Index()
        {
            var listOfAnimlas = _animalService.GetAll();
            AnimalListModel model = GetModel(listOfAnimlas);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnimalModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MessageType = "danger";
                model.Message = "Some Fields are not valid, please check the individual inputs fields.";
                return View("Index", model);
            }

            var result = _animalService.Add(GetAnimal(model));

            if (result == null)
            {
                model.MessageType = "danger";
                model.Message = "Error while saving the animal. Try again and contact support if the problem persists.";
                return View("Index", model);
            }

            model.MessageType = "success";
            model.Message = "The animal was successfully added.";
            return View("Index", model);
        }

        #region Mapping

        private Animal GetAnimal(AnimalModel model)
        {
            return new Animal()
            {
                Name = model.Name,
                DoB = model.DoB
            };
        }

        private AnimalListModel GetModel(IEnumerable<Animal> listOfAnimlas)
        {
            if (listOfAnimlas == null)
            {
                return new AnimalListModel()
                {
                    MessageType = "danger",
                    Message = "Error while loding the animals list. Please try refreshing the page and inform support if it doesnt' work."
                };
            }

            var list = new List<AnimalModel>();
            foreach (Animal a in listOfAnimlas)
            {
                list.Add(new AnimalModel() { Id = a.Id, DoB = a.DoB, Name = a.Name });
            }

            return new AnimalListModel()
            {
                Title = "List of Animals",
                List = list
            };
        }

        #endregion
    }
}
