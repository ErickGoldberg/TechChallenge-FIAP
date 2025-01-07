using Contacts.Domain.Entities;
using Contacts.Domain.ValueObjects;
using Contacts.Infraestructure.Persistence;

namespace Contacts.Infraestructure.SeedTest
{
    public static class SeedData
    {
        public static void SeedTestContacts(ContactsDbContext context)
        {
            context.Contatos.Add(new Contact(new Name("Macoratti", "Dev"), new Email("macoratti.dev@gmail.com"), new Phone(81, 123456789)));
            context.Contatos.Add(new Contact(new Name("Danilo", "Aparecido"), new Email("danilo.aparecidoDev@hotmail.com"), new Phone(11, 987654321)));
            context.SaveChanges();
        }
    }
}
