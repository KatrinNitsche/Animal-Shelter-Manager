using ASM.DAL.Interfaces;
using ASM.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM.DAL.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<Address> GetAll()
        {
            return this.Context.Addresses;
        }

        public override IQueryable<Address> GetAll(bool asyn = true)
        {
            throw new NotImplementedException();
        }

        public override Address GetById(Guid id)
        {
            return this.Context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public override Address ToggleActive(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
