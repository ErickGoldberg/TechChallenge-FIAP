using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain
public class Email(string endereco)
{
    [Required]
    [EmailAddress(ErrorMessage = "O endereço de email não é valido")]
    public string Endereco { get; private set; } = endereco;

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType()) return false;

        var outroEmail = (Email)obj;
        return Endereco == outroEmail.Endereco;
    }

    public override int GetHashCode()
    {
        return Endereco.GetHashCode();
    }
}
