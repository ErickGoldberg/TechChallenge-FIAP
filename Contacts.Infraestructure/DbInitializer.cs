using Contacts.Infraestructure.Persistence;
using Contacts.Infraestructure.SeedTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infraestructure
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<ContactsDbContext>>();
            using (var context = new ContactsDbContext(options))
            {
                if (context.Database.IsInMemory()) 
                {
                    SeedData.SeedTestContacts(context);
                    return; 
                }

                context.Database.Migrate();
            }
        }
    }
}
