using ASM.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM.DAL
{
    public class DataContext : IdentityDbContext<User, UserRole, int>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Settings> Settings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}
