using Contacts.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetContactsAsync();
        Task<List<ContactDto>> GetContactsByDDDAsync(int DDD);
        Task<ContactDto> GetContactByIdAsync(Guid id);
        Task CreateContactAsync(ContactDto contato);
        Task UpdateContactAsync(ContactDto contact);
        Task DeleteContactAsync(Guid id);
    }
}
