namespace Contacts.Domain.Repositories
{
    public interface IContactsRepository
    {
        Task<List<Contato>> GetContactsAsync();
        Task<List<Contato>> GetContactsByDDDAsync(int DDD);
        Task<Contato> GetContactByIdAsync(Guid id);
        Task CreateContactAsync(Contato contato);
        Task UpdateContactAsync(Contato contact);
        Task DeleteContactAsync(Guid id);
    }
}
