using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infraestructure.Persistence
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco).HasColumnName("EmailAddress");
            });

            modelBuilder.Entity<Contact>().OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName("FirstName");
                name.Property(n => n.LastName).HasColumnName("LastName");
            });

            modelBuilder.Entity<Contact>().OwnsOne(c => c.Phone, phone =>
            {
                phone.Property(p => p.DDD).HasColumnName("PhoneDDD");
                phone.Property(p => p.Number).HasColumnName("PhoneNumber");
            });
        }
    }
}
