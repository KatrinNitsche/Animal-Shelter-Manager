using System;

namespace ASM.Data
{
    public class Settings
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Address Address { get; set; }

        public ContactDetails ContactDetails { get; set; }
    }
}
