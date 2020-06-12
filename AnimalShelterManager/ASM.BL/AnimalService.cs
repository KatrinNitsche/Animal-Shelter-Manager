using ASM.BL.Interfaces;
using ASM.DAL.Interfaces;
using ASM.Data;
using System.Collections.Generic;

namespace ASM.BL
{
    public class AnimalService : IAnimalService
    {
        private IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Animal Add(Animal newAnimal)
        {
            return _animalRepository.Add(newAnimal);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }
    }
}
