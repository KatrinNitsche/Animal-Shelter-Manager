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


        #region Mapping

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
