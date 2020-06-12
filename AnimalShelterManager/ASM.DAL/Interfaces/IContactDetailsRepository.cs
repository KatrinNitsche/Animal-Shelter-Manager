using ASM.Data;
using System;
using System.Collections.Generic;

namespace ASM.DAL.Interfaces
{
    public interface IContactDetailsRepository
    {
        IEnumerable<ContactDetails> GetAll();
        ContactDetails GetById(Guid id);
        ContactDetails Update(ContactDetails entry);

        ContactDetails Add(ContactDetails entry);

        void Commit();
    }
}
