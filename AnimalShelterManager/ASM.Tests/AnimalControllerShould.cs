using ASM.BL;
using ASM.BL.Interfaces;
using ASM.DAL;
using ASM.DAL.Interfaces;
using ASM.DAL.Repositories;
using ASM.Web.Controllers;
using ASM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ASM.Tests
{
    public class AnimalControllerShould
    {
        private ILogger<AnimalController> logger;
        private DbContextOptions<DataContext> options;

        public AnimalControllerShould()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            logger = factory.CreateLogger<AnimalController>();

            options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase("InMemoryData")
               .Options;
        }

        [Fact]
        public void BeCreated()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);
                IAnimalService animalService = new AnimalService(repository);
                AnimalController sut = new AnimalController(logger, animalService);
                Assert.NotNull(sut);
            }
        }

        [Fact]
        public void ReturnIndexPage()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);
                IAnimalService animalService = new AnimalService(repository);
                AnimalController sut = new AnimalController(logger, animalService);

                var response = sut.Index();

                Assert.NotNull(response);
            }
        }

        [Fact]
        public void ReturnIndexPageWithViewModel()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);
                IAnimalService animalService = new AnimalService(repository);
                AnimalController sut = new AnimalController(logger, animalService);

                var response = sut.Index();

                var viewResult = Assert.IsType<ViewResult>(response);
                AnimalListModel model = viewResult.ViewData.Model as AnimalListModel;

                Assert.Equal("List of Animals", model.Title);
                Assert.NotNull(model.List);
            }
        }
    }
}
