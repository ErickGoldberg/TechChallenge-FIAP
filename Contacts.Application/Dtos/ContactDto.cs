using Contacts.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
