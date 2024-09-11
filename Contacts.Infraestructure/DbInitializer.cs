using Contacts.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infraestructure
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContactsDbContext(serviceProvider.GetRequiredService<DbContextOptions<ContactsDbContext>>()))
            {
                context.Database.Migrate();
            }
        }
    }
}
