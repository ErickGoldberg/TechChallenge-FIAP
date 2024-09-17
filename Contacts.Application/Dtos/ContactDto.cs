using Contacts.Domain.ValueObjects;

namespace Contacts.Application.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }

        public ContactDto(Guid id, Name name, Email email, Phone phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
