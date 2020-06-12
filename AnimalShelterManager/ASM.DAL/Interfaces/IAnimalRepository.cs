using ASM.Data;
using System.Collections.Generic;

namespace ASM.DAL.Interfaces
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAll();
        Animal Add(Animal newAnimal);
    }
}
