using Contacts.Domain.Entities;

namespace Contacts.Domain.Repositories
{
    public interface IContactsRepository
    {
        Task<List<Contact>> GetContactsAsync();
        Task<List<Contact>> GetContactsByDDDAsync(int DDD);
        Task<Contact> GetContactByIdAsync(Guid id);
        Task CreateContactAsync(Contact contato);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}
