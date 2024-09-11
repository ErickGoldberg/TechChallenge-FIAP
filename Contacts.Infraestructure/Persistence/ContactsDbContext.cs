using Contacts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infraestructure.Persistence
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
