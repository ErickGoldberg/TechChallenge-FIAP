using Contacts.Application.Dtos;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services
{
    public class ContactService : IContactService
    {
        //db
        readonly IContactsRepository _contactRepository;

        public ContactService(IContactsRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

       
        public async Task CreateContactAsync(ContactDto contatoDto)
        {
            Contact contato = new Contact(contatoDto.Name, contatoDto.Email, contatoDto.Phone);
            await _contactRepository.CreateContactAsync(contato);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }

        public async Task<ContactDto> GetContactByIdAsync(Guid id)
        {
            var result = await _contactRepository.GetContactByIdAsync(id);
            return new ContactDto(result.Id, result.Name, result.Email, result.Phone);
        }

        public async Task<List<ContactDto>> GetContactsAsync()
        {
            var result = await _contactRepository.GetContactsAsync();
            return result.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();
        }

        public async Task<List<ContactDto>> GetContactsByDDDAsync(int DDD)
        {
            var result = await _contactRepository.GetContactsByDDDAsync(DDD);
            return result.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();
        }

        public async Task UpdateContactAsync(ContactDto contatoDto)
        {
            Contact contato = new Contact(contatoDto.Name, contatoDto.Email, contatoDto.Phone);
            await _contactRepository.UpdateContactAsync(contato);
        }
    }
}
