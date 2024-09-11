using Contacts.Domain;
using Contacts.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infraestructure.Persistence.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _context;

        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }
        public async Task CreateContactAsync(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

            if (contact is null)
                throw new ArgumentException("Contato não encontrado.");

            _context.Contatos.Remove(contact);

            await _context.SaveChangesAsync();
        }

        public async Task<Contato> GetContactByIdAsync(Guid id)
        {
            var contact = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

            return contact;
        }

        public async Task<List<Contato>> GetContactsAsync()
        {
            var contacts = await _context.Contatos.ToListAsync();

            return contacts;
        }

        public async Task<List<Contato>> GetContactsByDDDAsync(int DDD)
        {
            var contacts = await _context.Contatos.Where(x => x.DDD == DDD).ToListAsync();

            return contacts;
        }

        public async Task UpdateContactAsync(Contato contact)
        {
            _context.Contatos.Update(contact);

            await _context.SaveChangesAsync();
        }
    }
}
