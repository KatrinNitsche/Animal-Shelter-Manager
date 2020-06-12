using ASM.Data;
using System;
using System.Collections.Generic;

namespace ASM.DAL.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(Guid id);
        Address Update(Address entry);

        Address Add(Address entry);

        void Commit();
    }
}
