using Contacts.Domain.ValueObjects;

namespace Contacts.Domain.Entities;
public class Contact(Name name, Phone phone, Email email)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Name Nome { get; set; } = name;
    public Email Email { get; set; } = email;
    public Phone Telefone { get; set; } = phone;


    public void UpdateName(Name newName)
    {
        if (newName is null) throw new ArgumentException("O nome não pode ser vazio.");
        Nome = newName;
    }

    public void UpdateEmail(Email newEmail)
    {
        if (newEmail is null) throw new ArgumentException("O email não pode ser vazio.");
        Email = newEmail;
    }

    public void UpdatePhone(Phone newPhone)
    {
        if (newPhone is null) throw new ArgumentException("O telefone não pode ser vazio.");
        Telefone = newPhone;
    }
}

