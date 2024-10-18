using Contacts.Domain.ValueObjects;

namespace Contacts.Domain.Entities;
public class Contact
{
    public Contact()
    {

    }
    public Contact(Name name, Email email, Phone phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        Validate();
    }
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Phone Phone { get; set; }


    public void UpdateName(Name newName)
    {
        Name = newName
               ?? throw new ArgumentNullException("O nome não pode ser vazio.");
    }

    public void UpdateEmail(Email newEmail)
    {
        Email = newEmail
            ?? throw new ArgumentNullException("O email não pode ser vazio.");
    }

    public void UpdatePhone(Phone newPhone)
    {
        Phone = newPhone
            ?? throw new ArgumentNullException("O telefone não pode ser vazio.");
    }

    private void Validate()
    {
        if (Name is null)
            throw new ArgumentNullException("O nome não pode ser vazio.");
        if (Email is null)
            throw new ArgumentNullException("O email não pode ser vazio.");
        if (Phone is null)
            throw new ArgumentNullException("O telefone não pode ser vazio.");
    }
}

