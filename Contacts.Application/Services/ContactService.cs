using Contacts.Application.Abstraction;
using Contacts.Application.Dtos;
using Contacts.Application.InputModels;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using Contacts.Domain.ValueObjects;

namespace Contacts.Application.Services
{
    public class ContactService(IContactsRepository contactRepository) : IContactService
    {
        public async Task<Result> CreateContactAsync(CreateOrEditContactInputModel contactInputModel)
        {
            var contactName = new Name(contactInputModel.FirstName, contactInputModel.LastName);
            var contactEmail = new Email(contactInputModel.Email);
            var contactPhone = new Phone(contactInputModel.DDD, contactInputModel.Number);

            Contact contact = new Contact(contactName, contactEmail, contactPhone);

            await contactRepository.CreateContactAsync(contact);

            return Result.Success();
        }

        public async Task<Result> DeleteContactAsync(Guid id)
        {
            var contact = await contactRepository.GetContactByIdAsync(id);

            if (contact is null)
                return Result.Failure("Contact not found");

            await contactRepository.DeleteContactAsync(id);

            return Result.Success();
        }

        public async Task<Result<ContactDto>> GetContactByIdAsync(Guid id)
        {
            var result = await contactRepository.GetContactByIdAsync(id);

            if (result is null)
                return Result<ContactDto>.Success(null);

            var contactResult = new ContactDto(result.Id, result.Name, result.Email, result.Phone);

            return Result<ContactDto>.Success(contactResult);
        }

        public async Task<Result<List<ContactDto>>> GetContactsAsync()
        {
            var contacts = await contactRepository.GetContactsAsync();
            var contactsResult = contacts.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();

            return Result<List<ContactDto>>.Success(contactsResult);
        }

        public async Task<Result<List<ContactDto>>> GetContactsByDDDAsync(int DDD)
        {
            var contacts = await contactRepository.GetContactsByDDDAsync(DDD);
            var contactsResult = contacts.Select(r => new ContactDto(r.Id, r.Name, r.Email, r.Phone)).ToList();

            return Result<List<ContactDto>>.Success(contactsResult);
        }

        public async Task<Result> UpdateContactAsync(CreateOrEditContactInputModel contactInputModel)
        {
            var contact = await contactRepository.GetContactByIdAsync(contactInputModel.Id);

            if (contact is null)
                return Result.Failure("Contact not found");

            contact.Name = new Name(contactInputModel.FirstName, contactInputModel.LastName);
            contact.Email = new Email(contactInputModel.Email);
            contact.Phone = new Phone(contactInputModel.DDD, contactInputModel.Number);

            await contactRepository.UpdateContactAsync(contact);

            return Result.Success();
        }
    }
}
