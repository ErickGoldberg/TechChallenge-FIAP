using Contacts.Application.Abstraction;
using Contacts.Application.Dtos;
using Contacts.Application.InputModels;

namespace Contacts.Application.Services
{
    public interface IContactService
    {
        Task<Result<List<ContactDto>>> GetContactsAsync();
        Task<Result<List<ContactDto>>> GetContactsByDDDAsync(int DDD);
        Task<Result<ContactDto>> GetContactByIdAsync(Guid id);
        Task<Result> CreateContactAsync(CreateOrEditContactInputModel contactInputModel);
        Task<Result> UpdateContactAsync(CreateOrEditContactInputModel contactInputModel);
        Task<Result> DeleteContactAsync(Guid id);
    }
}
