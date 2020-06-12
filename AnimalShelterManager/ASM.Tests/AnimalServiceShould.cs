using ASM.BL;
using ASM.BL.Interfaces;
using ASM.DAL;
using ASM.DAL.Interfaces;
using ASM.DAL.Repositories;
using ASM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace ASM.Tests
{
    public class AnimalServiceShould 
    {
        private DbContextOptions<DataContext> options;

        public AnimalServiceShould()
        {
            options = new DbContextOptionsBuilder<DataContext>()
              .UseInMemoryDatabase("InMemoryData")
              .Options;
        }

        [Fact]
        public void ReturnAnimals()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);            
                IAnimalService sut = new AnimalService(repository);

                var listOfAnimals = sut.GetAll();

                Assert.NotNull(listOfAnimals);
            }
        }

        [Fact]
        public void AddAnAnimal()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);
                IAnimalService sut = new AnimalService(repository);

                var newAnimal = new Animal();
                var result = sut.Add(newAnimal);

                Assert.NotNull(result);
            }
        }

        [Fact]
        public void AddAnAnimalWidthDetails()
        {
            using (var context = new DataContext(options))
            {
                IAnimalRepository repository = new AnimalRepository(context);
                IAnimalService sut = new AnimalService(repository);

                var dob = DateTime.Now;
                var newAnimal = new Animal() { DoB = dob, Name = "Tommy the test cat" };
                var result = sut.Add(newAnimal);

                Assert.Equal("Tommy the test cat", result.Name);
                Assert.Equal(dob, result.DoB);
            }
        }
    }
}
