using Contacts.Domain.ValueObjects;

namespace Contacts.Domain.Entities;
public class Contact(Name name, Phone phone, Email email)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Name Name { get; set; } = name;
    public Email Email { get; set; } = email;
    public Phone Phone { get; set; } = phone;


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
}

