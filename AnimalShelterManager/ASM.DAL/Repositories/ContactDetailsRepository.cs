using ASM.DAL.Interfaces;
using ASM.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM.DAL.Repositories
{
    public class ContactDetailsRepository : BaseRepository<ContactDetails>, IContactDetailsRepository
    {
        public ContactDetailsRepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<ContactDetails> GetAll()
        {
            return this.Context.ContactDetails;
        }

        public override IQueryable<ContactDetails> GetAll(bool asyn = true)
        {
            throw new NotImplementedException();
        }

        public override ContactDetails GetById(Guid id)
        {
            return this.Context.ContactDetails.FirstOrDefault(x => x.Id == id);
        }

        public override ContactDetails ToggleActive(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
