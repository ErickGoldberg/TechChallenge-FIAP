using Contacts.Application.Dtos;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;

namespace Contacts.Application.Services
{
    public class ContactService(IContactsRepository contactRepository) : IContactService
    {
        public async Task CreateContactAsync(ContactDto contatoDto)
        {
            Contact contact = new Contact(contatoDto.Name, contatoDto.Email, contatoDto.Phone);
            await contactRepository.CreateContactAsync(contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await contactRepository.DeleteContactAsync(id);
        }

        public async Task<ContactDto> GetContactByIdAsync(Guid id)
        {
            var result = await contactRepository.GetContactByIdAsync(id);
            return new ContactDto(result.Id, result.Name, result.Email, result.Phone);
        }

        public async Task<List<ContactDto>> GetContactsAsync()
        {
            var result = await contactRepository.GetContactsAsync();
            return result.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();
        }

        public async Task<List<ContactDto>> GetContactsByDDDAsync(int DDD)
        {
            var result = await contactRepository.GetContactsByDDDAsync(DDD);
            return result.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();
        }

        public async Task UpdateContactAsync(ContactDto contatoDto)
        {
            Contact contact = new Contact(contatoDto.Name, contatoDto.Email, contatoDto.Phone);
            await contactRepository.UpdateContactAsync(contact);
        }
    }
}
