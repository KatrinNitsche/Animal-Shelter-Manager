using ASM.DAL;
using ASM.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ASM.Web
{
    internal static class DbContextSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<DataContext>())
            {
                if (context.Settings.Count() == 0)
                {
                    var address = new Address()
                    {
                        Line1 = "Address Line 1",
                        Line2 = "Address Line 2",
                        PostCode = "A12 3BC",
                        City = "London",
                        Country = "United Kingdom"
                    };

                    var contact = new ContactDetails()
                    {
                        Email = "Test@test.com",
                        Phone = "01234 56789",
                        Mobile = "09876 54321"
                    };

                    context.Settings.Add(new Settings()
                    {
                        Title = "Your Animal Shelter",
                        Address = address,
                        ContactDetails = contact
                    }
                    );

                }
            }
        }
    }
}