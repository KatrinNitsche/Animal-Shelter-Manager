using System;

namespace ASM.Data
{
    public class Settings
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Guid AddressId { get; set; }
        public Guid ContactDetailsId { get; set; }


        public virtual Address Address { get; set; }

        public virtual ContactDetails ContactDetails { get; set; }
    }
}
