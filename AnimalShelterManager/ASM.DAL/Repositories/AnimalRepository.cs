using ASM.DAL.Interfaces;
using ASM.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM.DAL.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<Animal> GetAll()
        {
            return Context.Animals;
        }

        public override IQueryable<Animal> GetAll(bool asyn = true)
        {
            throw new NotImplementedException();
        }

        public override Animal GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Animal ToggleActive(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
