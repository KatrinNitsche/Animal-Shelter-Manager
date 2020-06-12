using ASM.Data;
using System.Collections.Generic;

namespace ASM.BL.Interfaces
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAll();
        Animal Add(Animal newAnimal);
    }
}
