using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.ValueObjects;
public class Email
{
    public Email()
    {
    }

    public Email(string endereco)
    {
        Endereco = endereco;
    }

    [Required]
    [EmailAddress(ErrorMessage = "O endereço de email não é valido")]
    public string Endereco { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        var outroEmail = (Email)obj;
        return Endereco == outroEmail.Endereco;
    }

    public override int GetHashCode() =>
        Endereco.GetHashCode();
}
